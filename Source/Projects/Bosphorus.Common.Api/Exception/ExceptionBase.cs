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

namespace Bosphorus.Common.Api.Exception
{
    public class ExceptionBase : System.Exception
    {
        public ExceptionBase()
        {
        }

        public ExceptionBase(string message)
            : base(message)
        {
        }

        public ExceptionBase(ExceptionMessage exceptionMessage)
            : base(exceptionMessage.ToString())
        {
        }

        public ExceptionBase(System.Exception innerException)
            : base(string.Empty, innerException)
        {
        }

        public ExceptionBase(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        public ExceptionBase(ExceptionMessage exceptionMessage, System.Exception innerException)
            : base(exceptionMessage.ToString(), innerException)
        {
        }
    }
}
