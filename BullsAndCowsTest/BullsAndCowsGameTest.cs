using BullsAndCows;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            //var secretGenerator = new SecretGenerator();
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_0A0B_when_all_digital_and_positions_wrong()
        {
            //var secretGenerator = new SecretGenerator();
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            //when
            string answer = game.Guess("1 2 3 4");
            //then
            Assert.Equal("0A0B", answer);
        }

        //[Fact]
        [Theory]
        [InlineData("4 3 2 1")]
        [InlineData("4 3 1 2")]
        public void Should_return_0A0B_when_all_digital_right_and__no_positions(string guess)
        {
            //var secretGenerator = new SecretGenerator();
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            //when
            string answer = game.Guess("5 6 7 8");
            //then
            Assert.Equal("4A0B", answer);
        }

        [Fact]
        public void Should_return_0A0B_when_no_digital_right_and__all_positions_wrong()
        {
            //var secretGenerator = new SecretGenerator();
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            //when
            string answer = game.Guess("8 7 6 5");
            //then
            Assert.Equal("0A4B", answer);
        }

        public class TestSecretGenerator : SecretGenerator
        {
            public override string GenerateSecret()
            {
                return "5678";
            }
        }
    }
}
