using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace protocol.utils
{
    public class TextValidations
    {
        public void validateDigits(KeyPressEventArgs e, String text, int maxLength)
        {
            if (text.Length < maxLength || e.KeyChar == 8)
            {
                if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        public void validateLetters(KeyPressEventArgs e, String text, int maxLength)
        {
            if (text.Length < maxLength || e.KeyChar == 8)
            {
                if (Char.IsLetter(e.KeyChar) || e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        public void validateLettersWithSpace(KeyPressEventArgs e, String text, int maxLength)
        {
            if (text.Length < maxLength || e.KeyChar == 8)
            {
                if (Char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar.Equals(' '))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
        public void validateLettersOrDigits(KeyPressEventArgs e, String text, int maxLength)
        {
            if (text.Length < maxLength || e.KeyChar == 8)
            {
                if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        public void validateDecimals(KeyPressEventArgs e, String text, int maxLengthInt, int maxLengthDecimal)
        {

            if (Char.IsDigit(e.KeyChar) 
                || e.KeyChar.Equals('.') 
                || e.KeyChar.Equals(',')
                || e.KeyChar == 8)
            {
                if (e.KeyChar.Equals(','))
                { 
                  e.KeyChar='.';  
                }

                if (e.KeyChar.Equals('.'))
                {
                    if (text.Contains("."))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
                else 
                {
                    if (text.Contains("."))
                    {
                        String[] valores = text.Split('.');
                        if (valores.Length > 1)
                        {
                            if (valores[1].Length < maxLengthDecimal)
                            {
                                e.Handled = false;
                            }
                            else
                            {
                                if (e.KeyChar == 8)
                                {
                                    e.Handled = false;
                                }
                                else
                                {
                                    e.Handled = true;
                                }
                            }
                        }
                        else
                        {
                            e.Handled = false;

                        }
                    }
                    else
                    {
                        if (text.Length < maxLengthInt)
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        public void validateLength(KeyPressEventArgs e,String text,int maxLength)
        {
            if (text.Length < maxLength || e.KeyChar == 8)
            {           
                    e.Handled = false;       
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
