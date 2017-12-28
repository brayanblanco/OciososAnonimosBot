using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;


namespace OciososAnonimosBot {
    class Program {
        private DiscordSocketClient _client;
        private string _token;
        private string _blogChannelName;
        
        static void Main(string[] args) => new Program().MainAsync(args).GetAwaiter().GetResult();

        public async Task MainAsync(string[] args) {
            if (args.Length > 0) EvaluateArgs(args);

            _client = new DiscordSocketClient();

            _client.Log += Log;
            _client.MessageReceived += MessageReceived;

            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private void EvaluateArgs(string[] args) {
            for(var i = 0; i < args.Length; i = i + 2) {
                switch (args[i]) {
                    case "--token":
                        _token = args[i + 1];
                        break;

                    case "--blog":
                        _blogChannelName = args[i + 1];
                        break;
                }
            }
        }

        private Task Log(LogMessage msg) {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage message) {
            switch (message.Content) { 
                case "!hi":
                    await message.Channel.SendMessageAsync($"Hola {message.Author.Mention}");
                    break;

                case "!blog":
                    await message.Channel.SendMessageAsync("Pasa a leer nuestras reseñas en https://ociososanonimos.com");
                    break;                
            }
        }
    }
}
