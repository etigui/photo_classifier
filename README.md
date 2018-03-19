# Semester project HEPIA 2017-2018
![Micrisoft and Hepia logo](/image/logo.png)

## Project objectives and specifications

Studding and try [API Vision](https://azure.microsoft.com/en-us/services/cognitive-services/directory/vision/) of Microsoft, then program an application in C#, which is going to classify photo as mentioned in the point below:

1.	Get one or more photo of well-known people and try to associate the bunch of photo to that people.
2.	Get a list of photos which contain or not the people associate before.
3.	Compare by processing in the Azure cloud the photo using [Face API](https://azure.microsoft.com/en-us/services/cognitive-services/face/).
4.	If one person found, add this person to the database with all the features, like: age, hair color, emotion, gender, etc.., with the [Emotion API](https://azure.microsoft.com/en-us/services/cognitive-services/emotion/).
5.	With the [Compute vision API](https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/?cdn=disable), we will try to detect background element in the photo.  If something found add it the database.
6.	Program an application in C#, to search the photo added to the database.


## Face API specifications
- Supported image formats: JPEG, PNG, GIF (the first frame), BMP
- Supported input method: raw image binary or image URL 
- Face dimension detect: from 36x36 to 4096x4096 pixels
- Image file size: from 1KB to 4MB
- Face returned for an image: up to 64


## Vision API specifications
- Supported image formats: JPEG, PNG, GIF (the first frame), BMP
- Supported input method: raw image binary or image URL 
- Image dimension: must be at least 50x50 pixels
- Image file size: must be less than 4MB
