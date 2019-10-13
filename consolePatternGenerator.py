import random, sys, os

def cls():
    os.system('cls' if os.name=='nt' else 'clear')

def reverse(s):
    a = ''
    for i in s:
        a = i + a
    return a

def duplicate(times, lines):
    print('\n')
    for m in range(times):
        for i in range(len(lines)):
            lines[i] += lines[i]
    for m in range(times):
        for l in lines:
            print(l)
    print('\n')

def logo():
    cls()
    print("......................................................................")
    print(".   /$$$$$$$             /$$           /$$$$$$                       .")
    print(".  | $$__  $$           | $$          /$$__  $$                      .")
    print(".  | $$  \ $$ /$$$$$$  /$$$$$$       | $$  \__/  /$$$$$$  /$$$$$$$   .")
    print(".  | $$$$$$$/|____  $$|_  $$_//$$$$$$| $$ /$$$$ /$$__  $$| $$__  $$  .")
    print(".  | $$____/  /$$$$$$$  | $$ |______/| $$|_  $$| $$$$$$$$| $$  \ $$  .")
    print(".  | $$      /$$__  $$  | $$ /$$     | $$  \ $$| $$_____/| $$  | $$  .")
    print(".  | $$     |  $$$$$$$  |  $$$$/     |  $$$$$$/|  $$$$$$$| $$  | $$  .")
    print(".  |__/      \_______/   \___/        \______/  \_______/|__/  |__/  .")
    print("......................................................................")

def generate(cubeWidth, duplicateFactor):
    symbols = ['0', '.', '*', 'o', 'O', '+', '#', '|', '-']
    x = []
    
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

    m = input("")
    if(m == 'x'):
        exit()
    if(m == 'm'):
        menu(cubeWidth, duplicateFactor)
    logo()
    generate(cubeWidth, duplicateFactor)

def menu(cubeWidth, duplicateFactor):
    logo()
    print("\nWelcome to the Console Pattern Generator! At any point press 'X' to Exit the app or 'M' to reutn to this menu. Press any other key to generate a new pattern...\n")
    print("The app randomises a 'seed square' and then reflects this square a certain number of times to make a symmetric pattern of ASCII characters...\n")
    print("Note: If the pattern is not symmetrical then expand the terminal width\n")
    print("Current Seed Width: " + str(cubeWidth))
    print("Current Complexity Factor: " + str(duplicateFactor))
    print("\n")
    c = input("Enter the seed width you'd like... ")
    while not str(c).isdigit():
        c = input("That's not a number. Please enter the seed width you'd like... ")
    d = input("Enter the complexity factor you'd like... ")
    while not str(d).isdigit():
        d = input("That's not a number. Please enter the complexity factor you'd like... ")
    logo()
    generate(int(c), int(d))

menu(10, 2)