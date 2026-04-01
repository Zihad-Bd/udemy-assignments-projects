class Question
{
    public string questionText;
    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;
    public char correctAnswerLetter;
    private static char defaultCorrectAnswerLetter = 'X';

    public Question()
    {
        //TO DO: Initialize questionText, optionA, optionB, optionC, optionD as null. Initialize correctAnswerLetter to the value of static field 'defaultCorrectAnswerLetter'.
        questionText = null;
        optionA = null;
        optionB = null;
        optionC = null;
        optionD = null;
        correctAnswerLetter = defaultCorrectAnswerLetter;
    }

    public Question(string questionText)
    {
        //TO DO: Initialize questionText. Also, initialize optionA, optionB, optionC, optionD as null. Initialize correctAnswerLetter to the value of static field 'defaultCorrectAnswerLetter'.
        this.questionText = questionText;
        optionA = null;
        optionB = null;
        optionC = null;
        optionD = null;
        correctAnswerLetter = defaultCorrectAnswerLetter;
    }

    public Question(string questionText, string optionA, string optionB, string optionC, string optionD, char correctAnswerLetter)
    {
        //TO DO: Initialize questionText, optionA, optionB, optionC, optionD and correctAnswerText. Validate the value of correctAnswerLetter. It should either 'A', 'B', 'C' or 'D' only
        this.questionText = questionText;
        this.optionA = optionA;
        this.optionB = optionB;
        this.optionC = optionC;
        this.optionD = optionD;
        if (correctAnswerLetter == 'A' || correctAnswerLetter == 'B' || correctAnswerLetter == 'C' || correctAnswerLetter == 'D')
        {
            this.correctAnswerLetter = correctAnswerLetter;
        }
    }

    public bool AreOptionsValid()
    {
        //TO DO: Return true, if at least two options are not null
        int validOptionCount = 0;
        if (this.optionA != null)
        {
            ++validOptionCount;
        }
        if (this.optionB != null)
        {
            ++validOptionCount;
        }
        if (this.optionC != null)
        {
            ++validOptionCount;
        }
        if (this.optionD != null)
        {
            ++validOptionCount;
        }
        return validOptionCount >= 2;
    }
}

class Program
{
    static void Main()
    {
        //TO DO: Create an object of Question class and pass no arguments to the constructor
        Question question1 = new Question();

        //TO DO: Create an object of Question class and pass value for questionText only to the constructor.
        Question question2 = new Question("What is a tree?");
        //TO DO: Create an object of Question class and pass values for questionText, optionA, optionB, optionC, optionD and correctAnswerLetter to the constructor.
        Question question3 = new Question("What is the capital of Bangladesh?", "Rajshahi", "Dhaka", "Rangpur", "Barishal", 'B');
        //TO DO: Create an object of Question class and pass values for questionText, optionA, optionB, optionC, optionD only to the constructor.
        Question question4 = new Question("Currency of Bangladesh?") { optionA = "rupee", optionB = "dollar", optionC = "euro", optionD = "bdt" };
    }
}
