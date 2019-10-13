def printNumberHeading(lines):
    for l in lines:
        print(l)

def numberHeading(n):
    line = ['', '', '', '', '', '', '']
    if n==0:
        line[0] = '  0000.  '
        line[1] = '000. 000.'
        line[2] = '000. 000.'
        line[3] = '000. 000.'
        line[4] = '000. 000.'
        line[5] = '000. 000.'
        line[6] = '  0000.  '
        return line
    elif n==1:
        line[0] = ' 000.'
        line[1] = '0000.'
        line[2] = ' 000.'
        line[3] = ' 000.'
        line[4] = ' 000.'
        line[5] = ' 000.'
        line[6] = ' 000.'
        return line
    elif n==2:
        line[0] = ' 000000. '
        line[1] = '000. 000.'
        line[2] = '    000. '
        line[3] = '   000.  '
        line[4] = '  000.   '
        line[5] = ' 0000000.'
        line[6] = '00000000.'
        return line
    elif n==3:
        line[0] = ' 000000. '
        line[1] = '00.  000.'
        line[2] = '    000. '
        line[3] = '  0000.  '
        line[4] = '    000. '
        line[5] = '00.  000.'
        line[6] = ' 000000. '
        return line
    elif n==4:
        line[0] = '   00000.  '
        line[1] = '  00.000.  '
        line[2] = ' 00. 000.  '
        line[3] = '0000000000.'
        line[4] = '0000000000.'
        line[5] = '     000.  '
        line[6] = '     000.  '
        return line
    elif n==5:
        line[0] = '00000000.'
        line[1] = '00.      '
        line[2] = '0000000. '
        line[3] = '     000.'
        line[4] = '000. 000.'
        line[5] = '000. 000.'
        line[6] = ' 000000. '
        return line
    elif n==6:
        line[0] = ' 000000. '
        line[1] = '000. 000.'
        line[2] = '000.     '
        line[3] = '0000000. '
        line[4] = '000. 000.'
        line[5] = '000. 000.'
        line[6] = ' 000000. '
        return line
    elif n==7:
        line[0] = '00000000.'
        line[1] = '00000000.'
        line[2] = '    000. '
        line[3] = '   000.  '
        line[4] = '  000.   '
        line[5] = '  000.   '
        line[6] = '  000.   '
        return line
    elif n==8:
        line[0] = ' 000000. '
        line[1] = '000. 000.'
        line[2] = '000. 000.'
        line[3] = ' 000000. '
        line[4] = '000. 000.'
        line[5] = '000. 000.'
        line[6] = ' 000000. '
        return line
    elif n==9:
        line[0] = ' 000000. '
        line[1] = '000. 000.'
        line[2] = '000. 000.'
        line[3] = ' 0000000.'
        line[4] = '     000.'
        line[5] = '000. 000.'
        line[6] = ' 000000. '
        return line

def doubleDigit(n):
    digit1 = numberHeading(int(str(n)[0]))
    digit2 = numberHeading(int(str(n)[1]))
    for i in range(len(digit1)):
        digit1[i] += " " + digit2[i]
    return digit1

def charString(n, c):
    s = ''
    for i in range(n):
        s += c
    return s

def spaceString(n):
    return charString(n, " ")


def addDegreeSymbol(lines):
    for i in range(len(lines)):
        if i == 0 or i == 2:
            lines[i] += "  O   OO"
        elif i == 1:
            lines[i] += " O O O  "
        else:
            lines[i] += "        "