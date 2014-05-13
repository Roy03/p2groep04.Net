namespace p2groep04.Models.Domain
{
    public class AdviceBPCState : SuggestionState
    {
        public AdviceBPCState(Suggestion suggestion) : base(suggestion)
        {
            
        }

        protected void GiveAdvice()
        {
            Suggestion.ToSubmittedState();
        }
    }
}
