using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace RevoApp.Hubs
{
    public class ChatHub : Hub
    {
        // Metin mesajı gönderimi (herkese)
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        // Sesli görüşmeyi başlat (herkese tetiklenir)
        // Eğer StartVoiceCall'da kullanıcı adı gerekiyorsa:
        public async Task StartVoiceCall(string user) // Kullanıcı adını parametre olarak al
        {
            await Clients.All.SendAsync("StartVoiceCall", user); // Herkese kimin başlattığını bildir
        }

        // Sesli görüşmeyi bitir (herkese tetiklenir)
        // Eğer EndVoiceCall'da kullanıcı adı gerekiyorsa:
        public async Task EndVoiceCall(string user) // Kullanıcı adını parametre olarak al
        {
            await Clients.All.SendAsync("EndVoiceCall", user); // Herkese kimin bitirdiğini bildir
        }

        // ICE adaylarını gönder
        public async Task SendICECandidate(string user, string candidate) // user ve candidate'ı string olarak al
        {
            await Clients.All.SendAsync("ReceiveICECandidate", user, candidate); // user'ı da gönder
        }

        // Offer gönder
        public async Task SendOffer(string user, string offer) // user ve offer'ı string olarak al
        {
            await Clients.All.SendAsync("ReceiveOffer", user, offer); // user'ı da gönder
        }

        // Answer gönder
        public async Task SendAnswer(string user, string answer) // user ve answer'ı string olarak al
        {
            await Clients.All.SendAsync("ReceiveAnswer", user, answer); // user'ı da gönder
        }
    }
}