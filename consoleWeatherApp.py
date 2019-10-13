import requests, sys, argparse, consoleHeadings, math, datetime
from datetime import datetime

width = 50

def printBlankLine():
    print("  |" + consoleHeadings.spaceString(windowWidth - 6) + "|  ")

def queryOpenWeather():
    city = raw_input("Enter the name of a city: ")
    country = raw_input("Enter the code of a country: ")
    print('...wait for it....')
    s = {'city':city, 'country':country, 'weather':requests.get('https://api.openweathermap.org/data/2.5/weather?q=' + city + ',' + country + '&appid=1e405c1b29aba5702e7dcd698c703d06')}
    if s["weather"].json()[u'cod'] is not 200:
        print("\nSorry, I can't find that place...\n")
        return queryOpenWeather()
    return s

x = queryOpenWeather()
city = x["city"]
country = x["country"]
weather = x["weather"]
place = str.upper(city) + ", " + str.upper(country)
temp = int(math.floor(weather.json()[u'main'][u'temp'] - 273.15))
humidity = int(weather.json()[u'main'][u'humidity'])
conditions = weather.json()[u'weather'][0][u'description']
sunrise = weather.json()[u'sys'][u'sunrise']
sunset = weather.json()[u'sys'][u'sunset']
currentTime = datetime.now().strftime("%H:%M")

print
print

if temp < 10:
    lines = consoleHeadings.numberHeading(temp)
else:
    lines = consoleHeadings.doubleDigit(temp)
consoleHeadings.addDegreeSymbol(lines)

print

tempWidth = len(lines[0])
tempSpaceString = consoleHeadings.spaceString(int((width - tempWidth)/2))

for i in range(len(lines)):
    lines[i] = "  |" + tempSpaceString + lines[i] + tempSpaceString + "|  "

windowWidth = len(lines[0])
print("   " + consoleHeadings.charString(windowWidth - 6, "_"))
print("  |" + place.center(windowWidth - 6, ' ') + "|  ")
print("  |" + currentTime.center(windowWidth - 6, ' ') + "|  ")

printBlankLine()
printBlankLine()
consoleHeadings.printNumberHeading(lines)
printBlankLine()
printBlankLine()

conditionsString = "  |  Conditions: " + conditions.title()
print(conditionsString + consoleHeadings.spaceString(windowWidth - len(conditionsString) - 3) + "|  ")
printBlankLine()
sunriseString = "  |  Sunrise: " + str(datetime.fromtimestamp(sunrise).time())
sunsetString = "  |  Sunset: " + str(datetime.fromtimestamp(sunset).time())
print(sunriseString + consoleHeadings.spaceString(windowWidth - len(sunriseString) - 3) + "|  ")
print(sunsetString + consoleHeadings.spaceString(windowWidth - len(sunsetString) - 3) + "|  ")
humidityString = "  |  Humidity: " + str(humidity) + "%"
print(humidityString + consoleHeadings.spaceString(windowWidth - len(humidityString) - 3) + "|  ")
printBlankLine()
print("   " + consoleHeadings.charString(windowWidth - 6, u"\u203e"))
print