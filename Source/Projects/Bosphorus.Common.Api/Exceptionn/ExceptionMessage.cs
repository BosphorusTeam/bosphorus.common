/*
  Bosphorus Enterprise Framework - The Open-Source Enterprise Framework
  Copyright (C) 2006-2008 Onur EKER <onur.eker@gmail.com>

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; either version 3 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System.Collections.Generic;
using System.Text;

namespace Bosphorus.Common.Api.Exceptionn
{
    public class ExceptionMessage
    {
        private readonly StringBuilder messageBuilder;
        private readonly IDictionary<string, object> parameters;

        public ExceptionMessage(string initialMessage)
        {
            messageBuilder = new StringBuilder(initialMessage);
            parameters = new Dictionary<string, object>();
        }

        public ExceptionMessage Add(string key, object value)
        {
            parameters.Add(key, value);
            return this;
        }

        public override string ToString()
        {
            string[] keys = new string[parameters.Count];
            parameters.Keys.CopyTo(keys, 0);

            for (int i = 0; i < keys.Length; i++)
            {
                if (i == 0)
                    messageBuilder.Append(": [");

                string key = keys[i];
                object value = parameters[key];
                string postString = (i != keys.Length - 1) ? ", " : "]";

                messageBuilder.AppendFormat("{0}: {1}", key, value);
                messageBuilder.Append(postString);
            }

            return messageBuilder.ToString();
        }

        public static ExceptionMessage Build(string message)
        {
            return new ExceptionMessage(message);
        }
    }
}
