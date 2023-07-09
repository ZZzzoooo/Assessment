using System.Net.Http;
using System.Threading.Tasks;

namespace UndoAssessment.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> ReadContentAsJsonAsync<T>(this Task<HttpResponseMessage> taskMessage)
            => await (await taskMessage).ReadContentAsJsonAsync<T>();

        public static async Task<T> ReadContentAsJsonAsync<T>(this HttpResponseMessage message)
            => (await message.ReadAsStringAsync()).ParseAsJson<T>();

        public static Task<string> ReadAsStringAsync(this HttpResponseMessage message)
            => message.Content.ReadAsStringAsync();
    }
}