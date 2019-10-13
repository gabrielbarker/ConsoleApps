import random, sys

def reverse(s):
    a = ''
    for i in s:
        a = i + a
    return a

def duplicate(times, lines):
    print '\n\n'
    for m in range(times):
        for i in range(len(lines)):
            lines[i] += lines[i]
    for m in range(times):
        for l in lines:
            print l
    print '\n\n'

def generate():
    symbols = ['0', '.', '*', 'o', 'O', '+', '#', '|', '-']
    x = []
    cubeWidth = 10
    duplicateFactor = 2

    # if random.randint(0,1) == 1:
    #     cubeWidth = 5
    #     duplicateFactor = 4
    
    width = 2 * cubeWidth

    for i in range(cubeWidth):
        x.append(random.choice(symbols))

    cubeLines = []
    lines = []

    for n in range(cubeWidth):
        cubeLines.append('')
        lines.append('')
        lines.append('')
    
    for i in range(cubeWidth):
        for j in range(cubeWidth):
            cubeLines[i] += str(random.randint(0, 1))

    for i in range(cubeWidth):
        for j in range(cubeWidth):
            if cubeLines[i][j] == '1':
                lines[i] += x[i]
                lines[(width - 1) - i] += x[i]
            else:
                lines[i] += ' '
                lines[(width - 1) - i] += ' '

    i = cubeWidth - 1
    j = cubeWidth - 1

    for i in range(len(lines)):
        s = reverse(lines[i])
        lines[i] += s

    duplicate(duplicateFactor, lines)

    m = raw_input("")
    if(m == 'x'):
        exit()
    generate()

generate()