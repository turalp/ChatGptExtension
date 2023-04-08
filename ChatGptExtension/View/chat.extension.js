document.addEventListener('DOMContentLoaded', () => {
    const messageForm = document.getElementById('message-form');
    const messageInput = document.getElementById('message-input');
    const chatWindow = document.getElementById('chat-window');

    messageForm.addEventListener('submit', (event) => {
        event.preventDefault();

        const messageText = messageInput.value.trim();
        if (!messageText) return;

        appendMessage(messageText, 'user');
        messageInput.value = '';
    });

    function appendMessage(text, sender) {
        const messageElement = document.createElement('div');
        messageElement.classList.add('message');
        messageElement.classList.add(sender);
        messageElement.innerText = text;

        chatWindow.appendChild(messageElement);

        // Scroll to the bottom of the chat window
        chatWindow.scrollTop = chatWindow.scrollHeight;
    }
});
