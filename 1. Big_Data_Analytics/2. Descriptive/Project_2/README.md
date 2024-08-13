# Sentiment Analysis on IMDB Reviews using LSTM and Keras

<b>Sentiment Analysis</b> is a classification of emotions (in this case, positive and negative) on text data using text analysis techniques (I use LSTM).

<b>LSTM</b> (Long Short-Term Memory) is one of the Recurrent Neural Network (RNN) architecture used in Deep Learning.

<b>Keras</b> is an open-source Python Deep Learning library, that could be run on Tensorflow back-end.


### Dataset
<hr>
In this work, I use the <a href="https://www.tensorflow.org/api_docs/python/tf/keras/datasets/imdb/load_data">Keras API</a> to load the data of IMDB dataset.
</p>
This is a dataset for binary sentiment classification containing substantially more data than previous benchmark datasets. We provide a set of 25,000 highly polar movie reviews for training, and 25,000 for testing. There is additional unlabeled data for use as well. Raw text and already processed bag of words formats are provided. See the README file contained in the release for more details.

### Steps
<hr>
<ol type="1">
    <li>Import all the dependencies</li>
    <li>Defining Key Values</li>
    <li>Loading the data</li>
    <li>Data preprocessing</li>
    <li>Building the model</li>
    <li>Training the model</li>
    <li>Evaluating the model</li>
    <li>Plotting results</li>
</ol>

### Model Architecture
<hr>
<ol type="1">
    <li>Embedding Layer</li>
    <li>LSTM Layer</li>
    <li>Dense (activation function using sigmoid)</li>
    <li>Optimizer: Rmsprop, Loss Function: Binary Crossentropy</li>
</ol>

### Model Tuning
<hr>
<ol type="1">
    <li>Increase the number of epochs</li>
    <li>Reduce batch size</li>
    <li>Change the optimizer from rmsprop to adam</li>
    <li>Increase the maximun number of words to consider</li>
    <li>Increase the number of dictinct words</li>
    <li>Reduce the size of the vector space in which words will be embedded</li>
    <li>Reduce the number of LSTM units</li>
    <li>Add dropout layer</li>
    <li>Add early stopper</li>
</ol>

### Comparing with GRU
<hr>
Here we will carry out a comparative analysis of our LSTM tuned model with another RNN: Gated Recurrent Units (GRU)
    
### References
<hr>
<li><a href=https://medium.com/geekculture/10-hyperparameters-to-keep-an-eye-on-for-your-lstm-model-and-other-tips-f0ff5b63fcd4>
    https://medium.com/geekculture/10-hyperparameters-to-keep-an-eye-on-for-your-lstm-model-and-other-tips-f0ff5b63fcd4
</li>

<li><a href=https://deepdatascience.wordpress.com/2016/11/18/which-lstm-optimizer-to-use/>
    https://deepdatascience.wordpress.com/2016/11/18/which-lstm-optimizer-to-use/
</li>

<li><a href=https://www.kaggle.com/lakshmi25npathi/imdb-dataset-of-50k-movie-reviews>
    https://www.kaggle.com/lakshmi25npathi/imdb-dataset-of-50k-movie-reviews
</li>