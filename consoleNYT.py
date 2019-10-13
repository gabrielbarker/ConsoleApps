import requests, consoleHeadings, sys, os

categories = ["arts", "automobiles", "books", "business", "fashion", "food", "health", "home", "insider", "magazine", "movies", "national", "nyregion", "obituaries", "opinion", "politics", "realestate", "science", "sports", "sundayreview", "technology", "theater", "tmagazine", "travel", "upshot", "world"]

def cls():
    os.system('cls' if os.name=='nt' else 'clear')

def sendRequest(category):
    url = "https://api.nytimes.com/svc/topstories/v2/" + category + ".json?api-key=HkTU6pCXGaAMQQALxSogMeADFVG00IJB"
    storiesData = requests.get(url).json()
    return storiesData

def displayStoriesList(storiesData):
    i = 1
    maxTitleLength = 0;
    for s in storiesData[u'results']:
        if len(s[u'title']) > maxTitleLength:
            maxTitleLength = len(s[u'title'])

    for s in storiesData[u'results']:
        print consoleHeadings.charString(maxTitleLength + 5, "-")
        print " " + str(i) + ". " + s[u'title']
        i = i + 1
    print consoleHeadings.charString(maxTitleLength + 5, "-")

def getStoryByIndex(storiesData, n):
    url = "https://api.nytimes.com/svc/search/v2/articlesearch.json?q=" + storiesData[u'results'][n][u'title'] + "&api-key=HkTU6pCXGaAMQQALxSogMeADFVG00IJB"
    print 
    response =  requests.get(url).json()[u'response'][u'docs'][0]
    return response

def displayStory(story):
    print(story[u'headline'][u'main'].upper())
    print
    print(story[u'lead_paragraph'])
    print

def displayCategoryOptions():
    i = 1
    for c in categories:
        print " " + str(i) + ". " + c
        i = i + 1

def getIntInput(message, max):
    n = 0
    while n >= max or n < 1:
        print
        n = int(raw_input(message))
    return n

def logo():
    print("--------------------------------------")
    print(" NN\  NN| EEEEEEE| WW|   WW|  SSSSSS| ")
    print(" NNN\ NN| EE|      WW|   WW| SSS|     ")
    print(" NN|N NN| EEEEEEE| WW WW WW|  SSSSS\  ")
    print(" NN| NNN| EE|      WWW/ WWW|     SSS| ")
    print(" NN|  NN| EEEEEEE| WW/   WW| SSSSSS/  ")
    print("--------------------------------------")

def runNewsApp():
    cls()
    logo()
    displayCategoryOptions()
    n = getIntInput("Enter the number of the category you wish to explore: ", len(categories) + 1) - 1
    cls()
    logo()
    category = categories[n]
    storiesData = sendRequest(category)
    displayStoriesList(storiesData)
    n = getIntInput("Enter the number of the story you wish to read: ", len(storiesData[u'results']) + 1) - 1
    cls()
    logo()
    story = getStoryByIndex(storiesData, n)
    displayStory(story)
    n = getIntInput("\n\n\nPress 1 to return to categories...", 10101)
    if n == 1:
        runNewsApp()

runNewsApp()