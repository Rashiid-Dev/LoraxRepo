using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
namespace SQSTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SQSTest()
        {
            var credentials = new BasicAWSCredentials("LKIAQAAAAAAABVFLGUOM", "D/o+pR0vJrtpa5XFOH84qMZhIO7gTh/hyzu7Ip7E");

            var config = new AmazonSQSConfig
            {
                ServiceURL = "http://localhost:4566",
                RegionEndpoint = RegionEndpoint.USEast1
            };
            try
            {
                using (var client = new AmazonSQSClient(credentials, config))
                {
                    var createRequest = new CreateQueueRequest
                    {
                        QueueName = "SQSTestQueue"
                    };

                    var createResponse = await client.CreateQueueAsync(createRequest);

                    string queueUrl = createResponse.QueueUrl;

                    var sendMessageRequest = new SendMessageRequest
                    {
                        QueueUrl = queueUrl,
                        MessageBody = "SQS Test Message"
                    };

                    await client.SendMessageAsync(sendMessageRequest);

                    var receiveMessageRequest = new ReceiveMessageRequest
                    {
                        QueueUrl = queueUrl
                    };

                    var receiveMessageResponse = await client.ReceiveMessageAsync(receiveMessageRequest);

                    foreach (var message in receiveMessageResponse.Messages)
                    {
                        Assert.Equals("4d16f8b417279ea45d05191fe69d3c60", message.Body);

                        var deleteMessageRequest = new DeleteMessageRequest
                        {
                            QueueUrl = queueUrl,
                            ReceiptHandle = message.ReceiptHandle
                        };

                        await client.DeleteMessageAsync(deleteMessageRequest);
                    }

                    var deleteQueueRequest = new DeleteQueueRequest
                    {
                        QueueUrl = queueUrl
                    };

                    await client.DeleteQueueAsync(deleteQueueRequest);
                }
            }
            catch (AmazonSQSException ex)
            {
                Console.WriteLine($"AmazonSQSException: {ex.Message}");
            }
            catch (AmazonServiceException ex)
            {
                Console.WriteLine($"AmazonServiceException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}