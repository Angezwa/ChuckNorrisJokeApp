using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DadJokesLibrary
{
    public class JokeGenerator
    {
        public async Task<string> GetRandomJokeAsync()
        {
            HttpClient client = new HttpClient();
            string dj = await client.GetStringAsync("https://icanhazdadjoke.com/slack");
            Gag gag = JsonConvert.DeserializeObject<Gag>(dj);

            string returnString = string.Empty;

            for (int i = 0; i < gag.attachments.Count; i++)
            {
                returnString = gag.attachments[i].text;
            }
            return returnString;
        }
    }
}


/*
{
"attachments":
[
    {
    "fallback":"I applied to be a doorman but didn't get the job due to lack of experience. That surprised me, I thought it was an entry level position.",
    "footer":"<https://icanhazdadjoke.com/j/IeiyIRSnbxc|permalink> - <https://icanhazdadjoke.com|icanhazdadjoke.com>",
    "text":"I applied to be a doorman but didn't get the job due to lack of experience. That surprised me, I thought it was an entry level position."
    }
],
"response_type":"in_channel","username":"icanhazdadjoke"
}
*/