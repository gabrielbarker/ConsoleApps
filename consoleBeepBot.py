import sys, random, re
beeps = ["beep", "boop", "bop", "beeeeep", "booop", "beebop"]
puncEnd = ["!", "..."]
puncMid = ["!", "..."]
minQlen = 3
maxQlen = 8
minRlen = 8
maxRlen = 16

x = "^b[e,o]*$p"

while True:
    l = random.choice(range(minQlen, maxQlen))
    q = ''
    for i in range(random.choice(range(minQlen, maxQlen))):
        q += random.choice(beeps) + " "
    q += random.choice(beeps)
    y = input(q + "?\n")
    while re.match("^b[e,o]*$p", y) is not None:
        y = input(random.choice(beeps) + "?\n")
    r = random.choice(beeps)
    r += random.choice(puncEnd) + " "
    for i in range(random.choice(range(minRlen, maxRlen))):
        r += random.choice(beeps) + " "
    r += random.choice(beeps)
    r += random.choice(puncEnd)
    print(r + "\n")
    print