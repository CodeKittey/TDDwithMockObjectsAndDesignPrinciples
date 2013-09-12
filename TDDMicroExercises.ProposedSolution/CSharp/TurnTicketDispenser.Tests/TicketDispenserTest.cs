using NUnit.Framework;

namespace TDDMicroExercises.OneSolution.TurnTicketDispenser.Tests
{
    [TestFixture]
    public class TicketDispenserTest
    {
        [Test]
        public void A_new_ticket_must_have_the_turn_number_subsequent_to_the_previous_ticket()
        {
            var ticketDispenser = new TicketDispenser();
            TurnTicket previousTicket = ticketDispenser.GetTurnTicket();

            TurnTicket newTicket = ticketDispenser.GetTurnTicket();

            Assert.Greater(newTicket.TurnNumber, previousTicket.TurnNumber, "turn number");
        }

        [Test]
        public void A_new_ticket_must_have_the_turn_number_subsequent_to_the_previous_ticket_from_another_dispencer()
        {
            var firstTicketDispenser = new TicketDispenser();
            TurnTicket previousTicket = firstTicketDispenser.GetTurnTicket();

            var secondTicketDispenser = new TicketDispenser();
            TurnTicket newTicket = secondTicketDispenser.GetTurnTicket();

            Assert.Greater(newTicket.TurnNumber, previousTicket.TurnNumber, "turn number");
        }

        [Test]
        public void After_ticket_10_come_ticket_11()
        {
            var mockTurnNumberSequence = new MockTurnNumberSequence();
            mockTurnNumberSequence.SetExpectedGetNextTurnNumber(11);
            var ticketDispenser = new TicketDispenser(mockTurnNumberSequence);

            TurnTicket newTicket = ticketDispenser.GetTurnTicket();

            Assert.AreEqual(11, newTicket.TurnNumber, "turn number");
            mockTurnNumberSequence.Verify();
        }
    }
}
