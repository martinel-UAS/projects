# Sentiment Analysis on IMDB Reviews using LSTM and Keras

<b>Sentiment Analysis</b> is a classification of emotions (in this case, positive and negative) on text data using text analysis techniques (I use LSTM).

<b>LSTM</b> (Long Short-Term Memory) is one of the Recurrent Neural Network (RNN) architecture used in Deep Learning.

<b>Keras</b> is an open-source Python Deep Learning library, that could be run on Tensorflow back-end.


### Dataset
<hr>
In this work, I use the Keras API to load the data of IMDB dataset <a href="https://www.tensorflow.org/api_docs/python/tf/keras/datasets/imdb/load_data"></a>

This is a dataset for binary sentiment classification containing substantially more data than previous benchmark datasets. We provide a set of 25,000 highly polar movie reviews for training, and 25,000 for testing. There is additional unlabeled data for use as well. Raw text and already processed bag of words formats are provided. See the README file contained in the release for more details.

### Steps
<hr>
<ol type="1">
    <li>1. Import all the dependencies</li>
    <li>2. Defining Key Values</li>
    <li>3. Loading the data</li>
    <li>4. Data preprocessing</li>
    <li>5. Building the model</li>
    <li>6. Compiling and fitting the model</li>
    <li>7. Evaluating the model</li>
    <li>8. Plotting results</li>
</ol>

### Model Architecture
<hr>
<ol type="1">
    <li>Embedding Layer</li>
    <li>LSTM Layer</li>
    <li>Dense (activation function using RELU)</li>
    <li>Dense (activation function using Sigmoid)</li>
    <li>Optimizer: Adam, Loss Function: Binary Crossentropy</li>
</ol>
    

### References
<hr>
<li><a href="https://www.tensorflow.org/api_docs/python/tf/keras">
    https://www.tensorflow.org/api_docs/python/tf/keras</a>
</li>
<li><a href="https://github.com/sanjay-raghu/sentiment-analysis-using-LSTM-keras/blob/master/lstm-sentiment-analysis-data-imbalance-keras.ipynb">
    https://github.com/sanjay-raghu/sentiment-analysis-using-LSTM-keras/blob/master/lstm-sentiment-analysis-data-imbalance-keras.ipynb</a>
</li>
<li><a href="https://towardsdatascience.com/sentiment-analysis-using-lstm-step-by-step-50d074f09948">
    https://towardsdatascience.com/sentiment-analysis-using-lstm-step-by-step-50d074f09948</a>
</li>
<li><a href="https://www.kaggle.com/ngyptr/lstm-sentiment-analysis-keras">
    https://www.kaggle.com/ngyptr/lstm-sentiment-analysis-keras</a>
</li>
<li><a href="https://www.youtube.com/watch?v=qpb_39IjZA0">
    https://www.youtube.com/watch?v=qpb_39IjZA0</a>
</li>
<li><a href="https://towardsdatascience.com/illustrated-guide-to-lstms-and-gru-s-a-step-by-step-explanation-44e9eb85bf21">
    https://towardsdatascience.com/illustrated-guide-to-lstms-and-gru-s-a-step-by-step-explanation-44e9eb85bf21</a>
</li>
<li><a href="https://medium.com/@hunterheidenreich/understanding-keras-dense-layers-2abadff9b990">
    https://medium.com/@hunterheidenreich/understanding-keras-dense-layers-2abadff9b990</a>
</li>

### My References
<hr>
<li><a href=https://medium.com/geekculture/10-hyperparameters-to-keep-an-eye-on-for-your-lstm-model-and-other-tips-f0ff5b63fcd4>
    https://medium.com/geekculture/10-hyperparameters-to-keep-an-eye-on-for-your-lstm-model-and-other-tips-f0ff5b63fcd4
</li>