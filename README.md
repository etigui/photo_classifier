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

<h2>Face API specifications <img src="/image/face.png"></h2>
Face API is a cloud-based service that provides the most advanced face algorithms. Face API has two main functions: face detection with attributes and face recognition. Face API detects up to 64 human faces with high precision face location in an image. And the image can be specified by file in bytes or valid URL. Face rectangle (left, top, width, and height) indicating the face location in the image is returned along with each detected face. Optionally, face detection extracts a series of face related attributes such as pose, gender, age, head pose, facial hair, and glasses.


- Supported image formats: JPEG, PNG, GIF (the first frame), BMP
- Supported input method: raw image binary or image URL 
- Face dimension detect: from 36x36 to 4096x4096 pixels
- Image file size: from 1KB to 4MB
- Face returned for an image: up to 64

<h2>Vision API specificationse <img src="/image/vision.png"></h2>
The Computer Vision API provides state-of-the-art algorithms to process images and return information. For example, it can be used to determine if an image contains mature content, or it can be used to find all the faces in an image. It also has other features like estimating dominant and accent colors, categorizing the content of images, and describing an image with complete English sentences. Additionally, it can also intelligently generate images thumbnails for displaying large images effectively.


- Supported image formats: JPEG, PNG, GIF (the first frame), BMP
- Supported input method: raw image binary or image URL 
- Image dimension: must be at least 50x50 pixels
- Image file size: must be less than 4MB
