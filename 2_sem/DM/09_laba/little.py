from pprint import pprint
import copy


def little(_matrix, _path=None, cost=0, level=0):
    if not _path:
        _path = []
    size = len(_matrix)
    if level == size - 1:
        for i in range(size):
            for j in range(size):
                if _matrix[i][j] != INF:
                    _path.append((i, j))
                    cost += _matrix[i][j]
                    return _path, cost

    matrix_copy = copy.deepcopy(_matrix)
    cost += reduce_matrix(matrix_copy)

    penalties = calculate_penalties(matrix_copy)
    if not penalties:
        return _path, INF

    selected = max(penalties, key=penalties.get)
    i, j = selected

    include_matrix = copy.deepcopy(matrix_copy)
    for k in range(size):
        include_matrix[i][k] = INF
        include_matrix[k][j] = INF
    include_matrix[j][i] = INF

    include_path = _path + [(i, j)]
    include_result = little(include_matrix, include_path, cost, level + 1)

    exclude_matrix = copy.deepcopy(matrix_copy)
    exclude_matrix[i][j] = INF
    exclude_result = little(exclude_matrix, _path[:], cost, level)

    return min(include_result, exclude_result, key=lambda x: x[1])


def calculate_penalties(_matrix):
    penalties = {}
    for i in range(len(_matrix)):
        for j in range(len(_matrix)):
            if _matrix[i][j] == 0:
                row = [_matrix[i][k] for k in range(len(_matrix)) if k != j]
                col = [_matrix[k][j] for k in range(len(_matrix)) if k != i]
                row_min = min([x for x in row if x != INF], default=0)
                col_min = min([x for x in col if x != INF], default=0)
                penalties[(i, j)] = row_min + col_min
    return penalties


def reduce_matrix(_matrix):
    cost = 0
    for i in range(len(_matrix)):
        row = _matrix[i]
        min_val = min(row)
        if min_val != INF:
            _matrix[i] = [x - min_val if x != INF else INF for x in row]
            cost += min_val

    for j in range(len(_matrix)):
        col = [_matrix[i][j] for i in range(len(_matrix))]
        min_val = min(col)
        if min_val != INF:
            for i in range(len(_matrix)):
                if _matrix[i][j] != INF:
                    _matrix[i][j] -= min_val
            cost += min_val

    return cost


INF = float("inf")
matrix = [
    [INF, 41, 40, 48, 40, 42],
    [48, INF, 41, 49, 42, 46],
    [22, 22, INF, 23, 24, 19],
    [15, 17, 11, INF, 10, 14],
    [47, 43, 18, 42, INF, 52],
    [34, 39, 30, 39, 32, INF]
]

if __name__ == '__main__':
    path, total_cost = little(matrix)
    print("Лучший путь:", path)
    print("Общая стоимость:", total_cost)


