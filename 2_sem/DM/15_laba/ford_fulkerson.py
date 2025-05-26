from collections import deque


def bfs(_residual_graph, _source, _sink, _parent):
    """вернет тру если сущестует путь из истока в сток"""
    visited = set()
    queue = deque([_source])
    visited.add(_source)

    # изменяем словарь родителей, добавляя поочередно
    while queue:
        u = queue.popleft()
        for v in _residual_graph[u]:
            if v not in visited and _residual_graph[u][v] > 0:
                _parent[v] = u
                visited.add(v)
                if v == _sink:
                    return True
                queue.append(v)
    return False


def ford_fulkerson(_graph, _source, _sink):
    # тут мы строим остаточный граф, добавляя обратные пути равные нулю, если таких нет
    residual_graph = {}
    for u in _graph:
        if u not in residual_graph:
            residual_graph[u] = {}

        for v in _graph[u]:
            if v not in residual_graph:
                residual_graph[v] = {}

            residual_graph[u][v] = _graph[u][v]
            if u not in residual_graph[v]:
                residual_graph[v][u] = 0

    max_flow = 0
    parent = {}

    while bfs(residual_graph, _source, _sink, parent):
        path_flow = float('inf')
        v = _sink
        while v != _source:
            u = parent[v]
            path_flow = min(path_flow, residual_graph[u][v])
            v = u

        v = _sink
        while v != _source:
            u = parent[v]
            residual_graph[u][v] -= path_flow
            residual_graph[v][u] += path_flow
            v = u

        max_flow += path_flow

    return max_flow


if __name__ == "__main__":
    # граф из варианта который я выбрал для решения вручную (lite)
    graph = {
        'i': {'1': 12, '2': 65, '4': 41},
        '1': {'4': 33, 's': 38, '3': 17},
        '2': {'4': 11, 's': 16},
        '3': {'s': 19, '2': 34},
        '4': {'s': 50},
        's': {},
    }

    source = 'i'
    sink = 's'
    max_flow = ford_fulkerson(graph, source, sink)
    print(max_flow)
