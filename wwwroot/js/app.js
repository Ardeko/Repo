let connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// WebRTC için değişkenler
let localStream;
let peerConnection;

// Bağlantıyı başlatıyoruz
connection.start().catch(err => console.error("SignalR Error: ", err));

// Mesaj al
connection.on("ReceiveMessage", function (user, message) {
    const msg = document.createElement("div");
    msg.classList.add("message");
    msg.textContent = `${user}: ${message}`;
    document.getElementById("messagesList").appendChild(msg);
    document.getElementById("messagesList").scrollTop = document.getElementById("messagesList").scrollHeight;
});

// Sesli görüşme başlatma
function startCall() {
    navigator.mediaDevices.getUserMedia({ audio: true })
        .then(stream => {
            localStream = stream;
            document.getElementById("localAudio").srcObject = stream;

            connection.invoke("StartVoiceCall", "username").catch(err => console.error(err));

            document.getElementById("endCallButton").style.display = "inline-block";
            document.getElementById("startCallButton").style.display = "none";
        })
        .catch(err => console.error("Error accessing media devices.", err));
}

// Sesli görüşmeyi sonlandırma
function endCall() {
    connection.invoke("EndVoiceCall", "username").catch(err => console.error(err));

    if (localStream) {
        localStream.getTracks().forEach(track => track.stop());
    }
    document.getElementById("endCallButton").style.display = "none";
    document.getElementById("startCallButton").style.display = "inline-block";
}

// Mesaj gönderme
function sendMessage() {
    const message = document.getElementById("messageInput").value;
    if (message.trim() === "") return;
    connection.invoke("SendMessage", "username", message).catch(err => console.error(err));
    document.getElementById("messageInput").value = "";
}
