using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.IO;

namespace SignalRChatRoomSample.Hubs
{
    public class StreamHub : Hub
    {
        public ChannelReader<string> ReadLogStream()
        {
            var channel = Channel.CreateUnbounded<string>();
            // 不能用await 不能用wait();
            _ = WriteFile(channel.Writer);

            return channel.Reader;
        }

        private async Task WriteFile(ChannelWriter<string> writer)
        {
            using (var streamReader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(),"LargeFiles/logsss.txt")))
            {
                string line;
                while ((line= streamReader.ReadLine())!=null)
                {
                    await writer.WriteAsync(line);
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
                writer.TryComplete();
            }
        }
    }
}
