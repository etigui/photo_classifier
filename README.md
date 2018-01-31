# Semester project HEPIA 2017-2018
![Micrisoft and Hepia logo][logo.png]

## Objective and specification

Studding and try ["API Vision"](https://azure.microsoft.com/en-us/services/cognitive-services/directory/vision/) of Microsoft, then program an application in C#, which is going to classify photo as mentioned in the point below:

1.	Get one or more photo of well-known people and try to associate the bunch of photo to that people.
2.	Get a list of photos which contain or not the people associate before.
3.	Compare by processing in the Azure cloud the photo using ["Face API"](https://azure.microsoft.com/en-us/services/cognitive-services/face/)
4.	If one person found, add this person to the database with all the features, like: age, hair color, emotion, gender, etc.., with the ["Emotion API"](https://azure.microsoft.com/en-us/services/cognitive-services/emotion/)
5.	With the ["Compute vision API"](https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/?cdn=disable), we will try to detect background element in the photo.  if something found we also add it the database
6.	Program an application in C#, to search the photo added to the database.
