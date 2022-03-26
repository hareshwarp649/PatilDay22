using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectMoodAnalyser;
namespace ReflecMoodAnaly4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
       
            public void SadMoodMessage()
            {
                //Arrange
                MoodAnalyser analyser = new MoodAnalyser("I am in a Sad mood");
                //Act
                string mood = analyser.AnalyseMood();
                //Assert
                Assert.AreEqual("Sad", mood);
            }

          
            [TestMethod]
            public void GivenHappyMessage()
            {
                //Arrange
                MoodAnalyser analyser = new MoodAnalyser("I am in a Happy mood");
                //Act
                string mood = analyser.AnalyseMood();
                //Assert
                Assert.AreEqual("Happy", mood);
            }


            [TestMethod]
            public void GivenEmptyMood_WhenAnalysed_ShouldThrowMoodAnalysisExceptionIndicatingEmptyMood()
            {
                try
                {
                    string message = string.Empty;
                    MoodAnalyser mood = new MoodAnalyser(message);
                    string moodStr = mood.AnalyseMood();
                }
                catch (ExceptionMoodAnaly e)
                {
                    Assert.AreEqual("Mood should not be empty", e.Message);
                }
            }
            [TestMethod]
            public void GivenNULLMood_WhenAnalysed_ShouldThrowMoodAnalysisExceptionIndicatingNULLMood()
            {
                try
                {
                    string? message = null;
                    MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                    string mood = moodAnalyse.AnalyseMood();
                }
                catch (ExceptionMoodAnaly e)
                {
                    Assert.AreEqual("Mood should not be null", e.Message);
                }
            }


            [TestMethod]
            public void GivenMoodAnalyserClassName_WhenAnalysed_ShouldReturn_MoodAnalyserObject()
            {
                object expected = new MoodAnalyser();
                object actual = FactoryException.MoodAnalyseObjectCreation("MoodAnalyserApp.MoodAnalyser", "MoodAnalyser");
                Assert.AreEqual(expected.GetType(), actual.GetType());
            }

          
            [TestMethod]
            public void GivenImproperClassName_WhenAnalyse_ShouldThrowMoodAnalysisException()
            {
                try
                {
                    object expected = new MoodAnalyser();
                    object actual = FactoryException.MoodAnalyseObjectCreation("abc", "abc");
                }
                catch (ExceptionMoodAnaly e)
                {
                    Assert.AreEqual("No such class found", e.Message);
                }
            }

            
            [TestMethod]
            public void GivenImproperConstructorName_WhenAnalyse_ShouldThrowMoodAnalysisException()
            {
                try
                {
                    object expected = new MoodAnalyser();
                    object actual = FactoryException.MoodAnalyseObjectCreation("Mood", "MoodAnalyser");
                }
                catch (ExceptionMoodAnaly e)
                {
                    Assert.AreEqual("Constructor not found", e.Message);
                }
            }

        
    }
}