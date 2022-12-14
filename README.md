                             Texting Game
INTRODUCTING:-   We Created a Web API for sending messages in a group and other persons in the group can guess who send the message, its a simple and a funny game  this is designed for the who loves texting.
We use Clean architecture and Entity Framework  for our application.
Steps you need to Follow to use our web api  :-
1st Register to our application  
2nd Login to the application
After registration part is done then we are enter the room
we are define two option
1. Create Room
2. Join Room
Create Room :-
AddRoom :- You can add with roomid and RoomName
UpdateRoom :- you edit an existing room with roomId
Get Room :-  you fetch the details of a room by userid
//And After Join the Room
Join Room :-
AddUserRoom :- adding users to the created room  using list at a time we join multiple user
DeleteuserRoom :- removing users from the existing room using list at a time we delete multiple user
and after user send the message
Get UserRoom :- fetch all the users for a given Room id
Messaging In Group:-
AddMessage :- Add a new message to the room with Id and message
Getmessage :-  Get all the messages from the room with name and timestamp and message
user should be given the option to guess the user mappings
AddGuess :- a list of the users in the key-value pairs with showing Impersonated so user choose one id after that room is closed the results have to be displayed
with roomid,Name and score
SMS :- We are sending the SMS  By using Twilio Api.
