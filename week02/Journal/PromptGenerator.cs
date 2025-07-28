namespace Journal
{
    internal class PromptGenerator
    {
        // Variables
        Random random = new Random();
        private List<string> prompts = new List<string>
            {
                "What are you grateful for today?",
                "Describe a happy moment from your day.",
                "What did you learn today?",
                "What challenge did you face today and how did you overcome it?",
                "What would you do differently if you could repeat the day?",
                "What made you smile today?",
                "What inspired you today?",
                "What would you like to achieve tomorrow?",
                "What are you worried about right now?",
                "What motivates you to keep going?",
                "What would you like to learn in the future?",
                "What makes you feel proud of yourself?",
                "What would you like to change in your life?",
                "What makes you feel at peace?",
                "What would you like to remember from this day in the future?",
                "What would you like to do more often?",
                "What would you like to do less often?",
                "What would you like to achieve next month?",
                "What would you like to achieve in your life?",
                "What would you do if you had a perfect day?",
            };

        // Constructor
        public string GetRandomPrompt()
        {
            int index = random.Next(prompts.Count);
            return prompts[index];
        }
    }
}
