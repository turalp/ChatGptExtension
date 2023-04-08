using ChatGptExtension.Properties;
using Settings = ChatGptExtension.Properties.Settings;

namespace ChatGptExtension.Constants
{
    internal static class JavascriptFunctions
    {
        internal static string AppendMessageFunction(string text, string sender)
        {
            return @$"const messageElement = document.createElement('div');
                messageElement.classList.add('message');
                messageElement.classList.add({sender});
                messageElement.innerText = {text};

                chatWindow.appendChild(messageElement);

                // Scroll to the bottom of the chat window
                chatWindow.scrollTop = chatWindow.scrollHeight;";
        }

        internal static string GetResponseFromChat(string request)
        {
            return @$"const openaiUrl = '{Settings.Default.OpenAIUrl}';

              const headers = {{
                'Authorization': 'Bearer {Settings.Default.ChatGptApiKey}',
                'Content-Type': 'application/json',
              }};

              const body = {{
                prompt: {request},
                max_tokens: 100, // Adjust the number of tokens as needed
                n: 1, // Number of completions to generate
                stop: null, // Sequence where the API will stop generating further tokens
                temperature: 1, // Sampling temperature, higher values (e.g., 1) make output more random, lower values (e.g., 0) make it more deterministic
              }};

              try {{
                const response = await fetch(openaiUrl, {{
                  method: 'POST',
                  headers: headers,
                  body: JSON.stringify(body),
                }});

                if (!response.ok) {{
                  throw new Error(`HTTP error! status: ${{response.status}}`);
                }}

                const data = await response.json();
                return data.choices[0].text;

              }} catch (error) {{
                console.error('Error fetching data:', error);
                throw error;
              }}";
        }
    }
}
