import os, random, sys

#          heart                 diamond          club             spade
suits = [" " + u"\u2665", " " + u"\u2666", " " + u"\u2667", " " + u"\u2664", "++"]
undealt = list(range(1,53))
players = []

class Card:
    def __init__(self, index):
        self.index = index
        self.faceValue = getFaceValue(self)
        self.suit = suits[(index//13)]
        self.value = getValue(self)

class Player:
    def __init__(self, name, type):
        self.name = name
        self.hand = []
        self.type = type
        self.bust = False

def getFaceValue(card):
    if card.index == 60:
        return "++"
    elif (card.index%13)  == 1:
        return "A "
    elif (card.index%13)  == 10:
        return "10"
    elif (card.index%13)  == 11:
        return "J "
    elif (card.index%13)  == 12:
        return "Q "
    elif (card.index%13)  == 0:
        return "K "
    else:
        return str(card.index%13) + " " 

def getValue(card):
    if (card.index%13)  == 1:
        return  11
    elif (card.index%13)  > 10:
        return 10
    elif (card.index%13)  == 0:
        return 10
    else:
        return (card.index%13) 

def getHandValue(hand):
    v = 0
    for h in hand:
        v += h.value
    return v

def printCards(cards):
    topLine = ""
    faceValueLine = ""
    suitLine = ""
    bottomLine = ""
    for c in cards:
        topLine += " __  "
        faceValueLine += "|" + c.faceValue + "| "
        suitLine += "|" + c.suit + "| "
        bottomLine += " " + u"\u203e" + u"\u203e" + "  "
    print(topLine)
    print(faceValueLine)
    print(suitLine)
    print(bottomLine)

def printPlayersCards(players):
    for p in players:
        printCards(p.hand)

def printPlayersCardsHidden(players):
    for p in players:
        if p.type == "dealer":
            printCards([Card(60), p.hand[1]])
        elif p.type == "human":
            printCards(p.hand)
        else:
            printCards([Card(60), Card(60)])

def nextCard():
    n = random.choice(undealt)
    undealt.remove(n)
    return Card(n) 

def dealPlayer(player, number):
    for x in range(number):
        player.hand.append(nextCard())

def yourTurn(player):
    while (getHandValue(player.hand) < 21 and player.hand.__len__() < 5):
        n = '';
        while (n != 'h' and n != 's'):
            n = input("Press 'H' to Hit or 'S' to Stick...   ")
            if n == 'x':
                exit()
        if n == 'h':
            hit(player)
        else:
            stick(player)
            break
    checkBust(player)

def dealerTurn(player, you):
    while (getHandValue(player.hand) < 21 and player.hand.__len__() < 5):
        if getHandValue(player.hand) <= getHandValue(you.hand):
            hit(player)
        else:
            stick(player)
            break
    checkBust(player)

def computerTurn(player):
    while (getHandValue(player.hand) < 21 and player.hand.__len__() < 5):
        if getHandValue(player.hand) > 15:
            hit(player)
        else:
            stick(player)
        checkBust(player)

def hit(player):
    player.hand.append(nextCard())

def stick(player):
    print("player stuck")

def checkBust(player):
    if getHandValue(player.hand) > 21:
        player.bust = True

def round(numberOfPlayers):
    initialisePlayers(numberOfPlayers)
    for p in players:
        if p.type == "dealer":
            dealerTurn(p, players[-1])
        elif p.type == "computer":
            computerTurn(p)
        elif p.type == "human":
            yourTurn(p)
        resetScreen()
        printPlayersCardsHidden(players)
    winner = Player("", "")
    winner.hand = [Card(2)]
    for p in filter(nonBustPlayer, players):
        if getHandValue(p.hand) > getHandValue(winner.hand):
            winner = p
    print(winner.name)

def initialisePlayers(numberOfPlayers):
    players.append(Player("The Dealer", "dealer"))
    for i in range(numberOfPlayers-2):
        players.append(Player("Player" + i, "computer"))
    players.append(Player("you", "human"))

    for p in players:
        dealPlayer(p, 2)
    printPlayersCardsHidden(players)

def nonBustPlayer(player):
    return not player.bust

def logo():
    print(suits[3] + ' BLACKJACK ' + suits[3])

def resetScreen():
    os.system('clear')
    logo()

round(2)