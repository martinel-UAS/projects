# Analytical Service Development

## The problem

**Used cars – The hidden business of an automotive brand**: During the last 10 years working in the automotive industry, I’ve discovered that one of the key business for an automotive brand is, on top of manufacture and sell new vehicles, to resell used vehicles in the secondhand market.

In Nissan concretely, thousands of vehicles returned from fleets, company cars or leased cars are sold in the secondhand market every year and, in order to make these cars visible for the customers, a huge number of advertisements are published daily.

In the case of Nissan Nordic, our team in the Used Cars department receive from our Nissan dealers in Finland, the information of the cars (model, mileage, year, etc.) and the pictures of those cars that need to be published.

All these pictures are filtered and published in our corporate website and all the information about the car is manually typed which is, of course,  not a very efficient process.

**The objective of this project is to carry out a license plate recognition system to get the car data with as less human intervention as possible.**

## Dataset and high level procedure

We got a dataset of 300 car images from our customer which has been used to train the model.

The first step has been to label every single image, highlighting the region of the picture where the car plate is located. To do this we have used [ImgLab] (https://imglab.in/#) which is a platform independent data annoation tool that runs directly from the browser, and has no prerequisites. It requires minimal CPU and memory and supports multiple formats such as dlib XML, dlib pts, Pascal VOC, COCO and Tensorflow.

Once we labeled all the images, we applied some preprocessing (resizing of images and annotations) and we split our data into train, validation and test sets to train and evaluate the performance of our model.

Finally, we use the predicited area given by our model to crop the images and center the car plate. With the obtained subset we apply some image processing tecniques (blur, grayscale, contours, etc) to identify the exact area of the plate and finally usign OCR we

## Steps

1. Import required libraries and define main varaibles
2. Read and resize images and save them into an array (X)
3. Parsing data from XML annotations, resize them to fit the new image sizes and save them into y
4. Verfy X and y shapes and print the first 20 images from the dataset
5. Preparing the data for the CNN
6. Convolutional Neural Network (CNN)
   1. Creating the model
   2. Compiling and training the model
   3. Evaluating the model
7. Plotting results
8. Predict
   .....Work in progress
9. Crop images around the area of the plate prediction
10. Read in a randomly selected Image, Grayscale and Blur it
11. Apply filter and find edges for localization
12. Find Contours and apply mask
13. Recognize the text using OCR

## Model Architecture

<ol type="1">
    <li>Tranfer learning using VGG16 model</li>
    <li>Flatten layer</li>
    <li>Dense Layer 128 (activation function using relu)</li>
    <li>Dense Layer 128 (activation function using relu)</li>
    <li>Dense Layer 64 (activation function using relu)</li>
    <li>Dense Layer 4 (activation function using sigmoid)</li>
    <li>Optimizer: Adam, Loss Function: MSE</li>
</ol>

## As IS

![](image/README/1651762094471.png)

## To BE

![](image/README/1651762191707.png)

## Analytics process

![](image/README/1651762288462.png)

## References

<li><a href=https://medium.com/programming-fever/license-plate-recognition-using-opencv-python-7611f85cdd6c>
    License Plate Recognition using OpenCV Python
</li>
<li><a href=https://harshthakare70.medium.com/number-plate-recognition-using-opencv-python-4de86163d609>
    Number Plate Recognition using OpenCV Python
</li>
<li><a href=https://www.linkedin.com/pulse/automatic-number-plate-recognition-step-stepguide-devi-g/>
    7 Steps to Build Automatic Number Plate Recognition in Python
</li>
<li><a href=https://www.kaggle.com/datasets/andrewmvd/car-plate-detection/code>
    Car License Plate Detection
</li>
<li><a href=https://towardsdatascience.com/transfer-learning-with-vgg16-and-keras-50ea161580b4>
    Transfer Learning with VGG16 and Keras
</li>
