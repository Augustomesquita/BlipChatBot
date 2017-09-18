using System;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using System.Diagnostics;
using Take.Blip.Client;
using Lime.Messaging.Contents;
using System.Globalization;
using System.Collections.Generic;

namespace MyBot
{
    /// <summary>
    /// Defines a class for handling messages. 
    /// This type must be registered in the application.json file in the 'messageReceivers' section.
    /// </summary>
    public class DateMessageReceiver : IMessageReceiver
    {
        private readonly ISender _sender;
        private readonly CultureInfo _cultureInfo;
        private readonly string _messageTemplate;

        public DateMessageReceiver(ISender sender, IDictionary<string, object> settings)
        {
            _sender = sender;
            if (settings.ContainsKey("culture"))
            {            
                _cultureInfo = new CultureInfo((string)settings["culture"]);
            }
            else
            {
                _cultureInfo = CultureInfo.InvariantCulture;
            }

            _messageTemplate = (string)settings["message"];
        }

        public Task ReceiveAsync(Message envelope, CancellationToken cancellationToken)
        {
            return _sender.SendMessageAsync(string.Format(_messageTemplate, DateTime.Now.ToString("g", _cultureInfo)), envelope.From, cancellationToken);
        }
    }
}