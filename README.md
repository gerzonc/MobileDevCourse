# Homework 4 - Consume a RestAPI

## Description: 
- Use the API of your finale project, making a request to that and displaying the data on the screen.

- Every member of the team must use a different endpoint

- The app must validate that there is Internet connection before doing the request, otherwise it should display an error message.

- You must elaborate this homework with the steps we saw in the course (Create an API Service folder, create an interface, etc.)

## About the API
The OpenDota API provides Dota 2 related data including advanced match data extracted from match replays.

You can find data that can be used to convert hero and ability IDs and other information provided by the API from the dotaconstants repository. Check more information about the API at: https://tinyurl.com/y48avajj

## The Heroes Endpoint

In my application I used the heroes endpoint because is the only thing I was interested to. With this endpoint I can get information about Dota 2's heroes, such as character ID, name, primary attack attribute and game roles. In further updates I plan to get information like: character image, tap to check heroe builds or heroe biography, etc.
