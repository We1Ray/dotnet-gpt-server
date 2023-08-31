using Microsoft.AspNetCore.Mvc;
using Azure;
using Azure.AI.OpenAI;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace netserver.Controllers
{
    [Route("[controller]")]
    public class GptController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            OpenAIClient client = new(
                new Uri(""),
                new AzureKeyCredential("")
             );

            Response<ChatCompletions> responseWithoutStream = await client.GetChatCompletionsAsync(
                "polory_test",
                new ChatCompletionsOptions()
                {
                    Messages =
                    {
                        new ChatMessage(ChatRole.System, @"You are an AI assistant that helps people find information."),
                        new ChatMessage(ChatRole.User, @"講一個笑話給我"),
                    },
                    Temperature = (float)0.7,
                    MaxTokens = 800,
                    NucleusSamplingFactor = (float)0.95,
                    FrequencyPenalty = 0,
                    PresencePenalty = 0,
                });

            ChatCompletions completions = responseWithoutStream.Value;
            return Ok(new JsonResult(completions));
        }


        // POST api/values
        [HttpPost]
        public async Task<ActionResult<string>> PostAsync([FromBody] Gpt request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Question))
            {
                return BadRequest("Invalid request data.");
            }

            OpenAIClient client = new(
                new Uri("https://deanshoes01.openai.azure.com/"),
                new AzureKeyCredential("4c7fccca7cb14b72926978c8dc4b12b3")
             );

            Response<ChatCompletions> responseWithoutStream = await client.GetChatCompletionsAsync(
                "polory_test",
                new ChatCompletionsOptions()
                {
                    Messages =
                    {
                        new ChatMessage(ChatRole.System, @"You are an AI assistant that helps people find information."),
                        new ChatMessage(ChatRole.User, request.Question),
                    },
                    Temperature = (float)0.7,
                    MaxTokens = 800,
                    NucleusSamplingFactor = (float)0.95,
                    FrequencyPenalty = 0,
                    PresencePenalty = 0,
                });

            ChatCompletions completions = responseWithoutStream.Value;
            return Ok(new JsonResult(completions));
        }
    }
}

