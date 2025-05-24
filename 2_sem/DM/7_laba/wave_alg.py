def wave_algorithm(_matrix, start, end):
    """Волновой алгоритм"""
    height = len(_matrix)
    width = len(_matrix[0])

    distances = list(map(lambda i: list(map(lambda _: float("inf"), i)), _matrix))
    visited = list(map(lambda i: list(map(lambda _: False, i)), _matrix))
    pointer = [start]

    distances[start[0]][start[1]] = 0
    visited[start[0]][start[1]] = True

    directions = (
        (0, 1),
        (0, -1),
        (1, 0),
        (-1, 0),
    )

    while pointer:
        x, y = pointer.pop(0)

        if x == end[0] and y == end[1]:
            return distances[x][y]

        for dx, dy in directions:
            new_x = x + dx
            new_y = y + dy
            if 0 <= new_x < height and 0 <= new_y < width and not visited[new_x][new_y] \
                    and _matrix[new_x][new_y] != float("inf"):
                visited[new_x][new_y] = True
                distances[new_x][new_y] = distances[x][y] + 1
                pointer.append((new_x, new_y))

    return


if __name__ == '__main__':
    matrix = [
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
        [0, float("inf"), 0, 0, float("inf"), 0, 0, float("inf"), 0, 0],
        [0, 0, 0, float("inf"), 0, 0, float("inf"), 0, 0, 0],
        [float("inf"), 0, 0, 0, 0, float("inf"), 0, 0, 0, 0],
        [0, 0, float("inf"), 0, 0, 0, 0, float("inf"), 0, 0],
        [0, 0, 0, 0, float("inf"), 0, 0, 0, 0, float("inf")],
        [0, float("inf"), 0, 0, 0, 0, float("inf"), 0, 0, 0],
        [0, 0, 0, float("inf"), 0, 0, 0, 0, float("inf"), 0],
        [0, 0, 0, 0, 0, float("inf"), 0, 0, 0, 0],
    ]

    print(wave_algorithm(matrix, (0, 0), (8, 9)))
