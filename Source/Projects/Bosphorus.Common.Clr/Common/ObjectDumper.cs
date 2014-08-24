#region -- Copyrights --
// ***********************************************************************
//  This file is a part of XSharper (http://xsharper.com)
// 
//  Copyright (C) 2006 - 2010, Alexei Shamov, DeltaX Inc.
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
// ************************************************************************
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Bosphorus.Common.Clr.Common
{
    /// Dump configuration
    public class DumpSettings
    {
        /// <summary>
        /// Maximum number of list or IEnumerable items to display
        /// </summary>
        public int MaxItems=50;

        /// <summary>
        /// true = display private members of the class/struct
        /// </summary>
        public bool DisplayPrivate=false;

        /// <summary>
        /// Limit tree depth to this (default 5)
        /// </summary>
        public int MaxDepth=5;

        /// <summary>
        /// Use full class names
        /// </summary>
        public bool UseFullClassNames = false;
    }

    /// <summary>
    /// Utility class to dump all properties and fields of the object to the output
    /// </summary>
    public class ObjectDumper
    {
        #region --- Constructors ---

        /// Constructor
        public ObjectDumper(object objectToDump) : this(objectToDump, null, null, 0)
        {
        }

        /// Constructor with explicit type specification
        public ObjectDumper(object objectToDump, Type type)
            : this(objectToDump, type, null, 0)
        {
        }

        /// Constructor with explicit type specification
        public ObjectDumper(object objectToDump, DumpSettings settings)
            : this(objectToDump, null, null, 0, settings)
        {
        }

        /// Constructor with explicit type specification and prefix
        public ObjectDumper(object objectToDump, Type type, string name)
            : this(objectToDump, type, name, 0)
        {
        }

        /// Constructor with explicit type specification, prefix, indent level 
        public ObjectDumper(object objectToDump, Type type, string name, int level)
            : this(objectToDump, type, name, level, s_defaultSettings)
        {
        }

        /// Constructor with explicit type specification
        public ObjectDumper(object objectToDump, Type type, DumpSettings settings)
            : this(objectToDump, type, null, 0, settings)
        {
        }

        /// Constructor with explicit type specification, prefix, indent level and depth level
        public ObjectDumper(object objectToDump, Type type, string name, int level, DumpSettings settings)
        {
            _object = objectToDump;
            _type = type;
            if (_type == null)
                if (objectToDump != null)
                    _type = objectToDump.GetType();
                else
                    _type = typeof (object);
            _name = name;
            _level = level;
            _settings = settings??s_defaultSettings;
        }

        #endregion

        /// Returns dump of the object
        public override string ToString()
        {
            try
            {
                _out.Length = 0;
                process2(_name, _type, _object, _level);
                return _out.ToString();
            }
            catch (System.Exception e)
            {
                return "??? thrown " + e.GetType().FullName;
            }
        }
        
        #region --- ToDump static methods ---

        /// Dump object to string
        public static string ToDump<T>(T objectToDump)
        {
            return ToDump<T>(objectToDump, null,null);
        }


        /// Dump object to string
        public static string ToDump<T>(T objectToDump, DumpSettings settings)
        {
            return ToDump<T>(objectToDump, null, settings);
        }


        /// Dump object to string, adding 'name=' prefix before output
        public static string ToDump<T>(T objectToDump, string name)
        {
            return ToDump(objectToDump, name,null);
        }

        /// Dump object to string, adding 'name=' prefix before output
        public static string ToDump<T>(T objectToDump, string name, DumpSettings settings)
        {
            return ToDump(objectToDump, (objectToDump == null) ? typeof(T) : objectToDump.GetType(), name, settings);
        }

        /// Dump object to string, interpreting object as the object of type 
        public static string ToDump(object objectToDump, Type type)
        {
            return ToDump(objectToDump, type, string.Empty);
        }

        /// Dump object to string, interpreting object as the object of type , adding 'name=' prefix before output
        public static string ToDump(object objectToDump, Type type, string name)
        {
            return new ObjectDumper(objectToDump, type, name, 0).ToString();
        }

        /// Dump object to string, interpreting object as the object of type , adding 'name=' prefix before output
        public static string ToDump(object objectToDump, Type type, string name, DumpSettings settings)
        {
            return new ObjectDumper(objectToDump, type, name, 0, settings).ToString();
        }

        /// Dump object to string, interpreting object as the object of type , adding 'name=' prefix before output
        public static string ToDump(object objectToDump, Type type, string name, int level)
        {
            return new ObjectDumper(objectToDump, type, name, level).ToString();
        }

        /// Dump object to string, interpreting object as the object of type , adding 'name=' prefix before output
        public static string ToDump(object objectToDump, Type type, string name, int level, DumpSettings settings)
        {
            return new ObjectDumper(objectToDump, type, name, level, settings).ToString();
        }

        #endregion
        #region -- Public static utility methods --
        /// <summary>
        /// Return a user-friendly type name of a given type. For example, int?[] instead of the default name
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Type name</returns>
        static public string GetFriendlyTypeName(Type type)
        {
            return GetFriendlyTypeName(type, false);
        }
        /// <summary>
        /// Return a user-friendly type name of a given type. For example, int?[] instead of the default name
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="fullName">Return full name of the type</param>
        /// <returns>Type name</returns>
        static public string GetFriendlyTypeName(Type type, bool fullName)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                Type st = Nullable.GetUnderlyingType(type);
                if (st != null)
                    return GetFriendlyTypeName(st) + "?";
                return "T?";
            }
            if (type.IsArray)
                return GetFriendlyTypeName(type.GetElementType()) + "[" + new string(',', type.GetArrayRank() - 1) + "]";

            string s;
            if (!fullName && s_friendlyName.TryGetValue(type, out s))
                return s;
            string name = fullName ? type.FullName : type.Name;
            if (type.IsGenericParameter || type.IsPrimitive || !type.IsGenericType || type == typeof(decimal))
                return name;

            StringBuilder builder = new StringBuilder();
            int index = name.IndexOf('`');
            if (index == -1)
                builder.Append(name);
            else
                builder.Append(name.Substring(0, index));
            builder.Append('<');
            bool first = true;
            foreach (Type arg in type.GetGenericArguments())
            {
                if (!first)
                {
                    builder.Append(',');
                }
                builder.Append(GetFriendlyTypeName(arg));
                first = false;
            }
            builder.Append('>');
            return builder.ToString();
        }
        #endregion
        #region -- Static configuration methods --

        /// Mark type as bloat. For bloattypes its ToString() output is copied to the dump instead of the proper tree walking.
        public static void AddBloatType(Type exc)
        {
            lock (s_bloatTypes)
                s_bloatTypes[exc.FullName] = true;
        }

        /// Mark type as bloat . For bloat types its ToString() output is copied to the dump instead of the proper tree walking.
        public static void AddBloatType(string typename)
        {
            lock (s_bloatTypes)
                s_bloatTypes.Add(typename, true);
        }

        /// Mark a property as bloat . For bloat properties its ToString() output is copied to the dump instead of the proper tree walking.
        public static void AddBloatProperty(Type type, string propertyName)
        {
            addProperty(type, propertyName, false);
        }

        /// Mark a property as one that should not be dumped, for example if the property has a side effect. 
        public static void AddHiddenProperty(Type type, string propertyName)
        {
            addProperty(type, propertyName, true);
        }

        /// Add a friendly type name
        public static void AddTypeName(Type type, string typename)
        {
            lock (s_bloatTypes)
                s_friendlyName.Add(type, typename);
        }
        #endregion


        #region --- Implementation details ---
        private readonly object _object;
        private readonly Type _type;
        private readonly string _name;
        private readonly int _level;
        private readonly DumpSettings _settings;
        private static readonly DumpSettings s_defaultSettings = new DumpSettings();


        private static void addProperty(Type type, string propertyName, bool sideEffect)
        {
            lock (s_propertyHints)
            {
                Dictionary<string, bool> prop;
                if (!s_propertyHints.TryGetValue(type, out prop))
                {
                    prop = new Dictionary<string, bool>();
                    s_propertyHints.Add(type, prop);
                }
                prop[propertyName]=sideEffect;
            }
        }
        
        private class ReferenceComparer : IEqualityComparer<object>
        {
            bool IEqualityComparer<object>.Equals(object x, object y)
            {
                return ReferenceEquals(x, y);
            }

            int IEqualityComparer<object>.GetHashCode(object obj)
            {
                if (ReferenceEquals(obj, null))
                    return 0;
                return obj.GetHashCode();
            }
        }

        private static readonly Dictionary<string, bool> s_bloatTypes = initBloatTypes();

        // For each special store true=side effect, false=bloat
        private static readonly Dictionary<Type, Dictionary<string,bool>> s_propertyHints = initPropertyHints();
        private static readonly Dictionary<Type, string> s_friendlyName = initFriendlyNames();

        private static Dictionary<string, bool> initBloatTypes()
        {
            Dictionary<string, bool> ret = new Dictionary<string, bool>();
            foreach (string s in new string[] {"System.DateTime",
                                            "System.Type",
                                            "System.Security.Principal.SecurityIdentifier",
                                            "System.Xml.Linq.XElement",
                                            "System.Xml.Linq.XDocument",
                                            "System.Reflection.RuntimeConstructorInfo",
                                            "System.Reflection.RuntimePropertyInfo",
                                            "System.Reflection.RuntimeMethodInfo",
                                            "System.RuntimeType",
                                            "System.Reflection.MethodBase",
                                            "System.Security.Policy.Evidence",
                                            "System.Globalization.CultureInfo",
                                            "System.Version"})
                ret[s] = true;
            return ret;
        }

        private static Dictionary<Type, string> initFriendlyNames()
        {
            Dictionary<Type, string> r=new Dictionary<Type, string>();
            r.Add(typeof(string),"string");
            r.Add(typeof(int), "int");
            r.Add(typeof(uint), "uint");
            r.Add(typeof(long), "long");
            r.Add(typeof(ulong), "ulong");
            r.Add(typeof(short), "short");
            r.Add(typeof(ushort), "ushort");
            r.Add(typeof(char), "char");
            r.Add(typeof(byte), "byte");
            r.Add(typeof(decimal), "decimal");
            r.Add(typeof(object), "object");
            r.Add(typeof(void), "void");
            r.Add(typeof(bool), "bool");
            return r;
        }

        private static Dictionary<Type, Dictionary<string,bool>> initPropertyHints()
        {
            Dictionary<Type, Dictionary<string, bool>> s = new Dictionary<Type, Dictionary<string, bool>>();

            // FileSystemInfo Parent and Root properties are examples of "bloat" properties and should be dumped with ToString
            Dictionary<string, bool> data = new Dictionary<string, bool>();
            data["Parent"] = false;
            data["Root"] = false;
            s[typeof(FileSystemInfo)] = data;
            return s;
        }

        private readonly StringBuilder _out = new StringBuilder(10000);
        readonly Dictionary<object, int> _usedMap = new Dictionary<object, int>(new ReferenceComparer());
        private int _counter = 0;

        void process2(string name, Type t, object o, int depth)
        {

            string typeName = GetFriendlyTypeName(t,_settings.UseFullClassNames);

            _out.Append(new string(' ', depth*2));
            if (!string.IsNullOrEmpty(name))
                _out.Append(name + " = ");
            
            _out.Append("(" + typeName + ") ");

            if (o == null)
            {
                _out.Append("<null>");
                return;
            }

            if ((t != typeof(string) && (o is string)) || _settings.MaxDepth <= depth)
            {
                _out.Append("\"" + toEscapedString(o)+"\" /* ToString */");
                return;
            }

            if (t == typeof (string) || (o is string))
            {
                _out.Append("\"" + toEscapedString(o) + "\"");
                return;
            }

            
            BindingFlags flags = BindingFlags.Instance | BindingFlags.FlattenHierarchy;
            if (!_settings.DisplayPrivate)
                flags |= BindingFlags.Public;
            PropertyInfo[] props = t.GetProperties(flags | BindingFlags.GetProperty);
            FieldInfo[] fi = t.GetFields(flags);

            
            if (t.IsPrimitive || t.IsEnum || (t.IsValueType && props.Length == 0 && fi.Length == 0) || s_bloatTypes.ContainsKey(t.FullName) || t== typeof(decimal))
            {
                if ((t == typeof (int)) || (t == typeof (byte)) || (t == typeof (uint)) || t == typeof (long) ||
                    t == typeof (ulong))
                    _out.AppendFormat(" {0} (0x{0:x})", o);
                else if (t == typeof (DateTime) || t == typeof(DateTime?))
                    _out.AppendFormat("{0:o} ({1})", o,((DateTime)o).Kind);
                else if (t == typeof (Guid))
                    _out.Append(((Guid) o).ToString("B"));
                else if (t == typeof(bool))
                    _out.Append(((bool)o)?"true":"false");
                else if (t.IsEnum)
                    _out.AppendFormat("[{0}] /* 0x{0:x} */", o);
                else
                    _out.AppendFormat("[{0}]", toEscapedString(o));
                return;
            }
            if (t.IsClass)
            {
                int id;
                if (_usedMap.TryGetValue(o,out id))
                {
                    _out.AppendFormat("<see #{0}, {1:x8} above>", id, o.GetHashCode());
                    return;
                }
                _usedMap[o] = ++_counter;
            }
            if (t.IsArray && ((Array) o).Rank == 1)
            {
                Array arr;
                if (t.IsArray)
                    arr = (o as Array);
                else
                    arr = t.GetMethod("ToArray").Invoke(o, new object[] {}) as Array;
                processArray(t, arr, depth);
            }
            else if (o as IEnumerable != null)
            {
                writeBrace(o);
                processEnumerables(o as IEnumerable, depth);
            }
            else
            {
                writeBrace(o);

                Dictionary<string,bool> propNames=null;
                foreach (KeyValuePair<Type, Dictionary<string,bool>> info in s_propertyHints)
                    if (t==info.Key || t.IsSubclassOf(info.Key))
                    {
                        propNames = info.Value;
                        break;
                    }

                foreach (PropertyInfo p in props)
                {
                    bool sideEffect;
                    if (propNames != null && propNames.TryGetValue(p.Name, out sideEffect))
                    {
                        if (!sideEffect)
                            dumpProperty(p, o, depth + 1, true);
                        else
                        {
                            process2(p.Name, p.PropertyType, "<ignored>", depth+1);
                            _out.AppendLine();
                        }
                    }
                    else
                        dumpProperty(p, o, depth + 1, false);
                }
                foreach (FieldInfo f in fi)
                    dumpField(f, o, depth + 1);

            }
            _out.Append(new string(' ', depth*2));
            _out.Append("}");
            
        }

        private static string toEscapedString(object o)
        {
            
            return o.ToString().Replace("\r", "\\r").Replace("\n", "\\n").Replace("\b", "\\b").Replace("\t", "\\t");
        }

        private void writeBrace(object o)
        {
            _out.AppendFormat("{{ /* #{0}, {1:x8} */ ", _counter, o.GetHashCode());
            _out.AppendLine();
        }

        private void dumpProperty(PropertyInfo p, object o, int level, bool asString)
        {
            try
            {
                if (p.GetIndexParameters().Length == 0)
                {
                    object obj = p.GetValue(o, null);
                    if (asString)
                        process2(p.Name, (obj == null) ? p.PropertyType : obj.GetType(), (obj??"<null>").ToString(), level);
                    else
                        process2(p.Name, (obj == null) ? p.PropertyType : obj.GetType(), obj, level);
                    _out.AppendLine();
                }
                else
                {
                    _out.Append(new string(' ', level * 2));
                    _out.AppendLine(p.Name + " = " + "("+GetFriendlyTypeName(p.PropertyType)+") ??? indexed property ignored");
                }
            }
            catch(System.Exception e)
            {
                _out.Append(new string(' ', level * 2));
                _out.AppendLine(p.Name + " = "+ "??? thrown "+e.GetType().FullName);
            }
        }

        private void dumpField(FieldInfo p, object o, int level)
        {
            try
            {
                object obj = p.GetValue(o);
                process2(p.Name, (obj == null) ? p.FieldType: obj.GetType(), obj, level);
                _out.AppendLine();
            }
            catch (System.Exception e)
            {
                _out.Append(new string(' ', level * 2));
                _out.AppendLine(p.Name + " = " + "??? thrown " + e.GetType().FullName);
            }
        }

        
        private void processEnumerables(IEnumerable enumerable, int nLevel)
        {
            int index = 0;
            foreach (object info in enumerable)
            {
                Type tinside=info == null ? typeof(object) : info.GetType();
                process2("[" + index + "]", tinside, info, nLevel + 1);
                _out.AppendLine();
                if (index++ > _settings.MaxItems)
                {
                    _out.AppendLine("...");
                    break;
                }
            }   
        }

        private void processArray(Type t, Array arr, int nLevel)
        {
            Type tInside = t.GetElementType();
            if (tInside == typeof(byte))
            {
                byte[] b = (byte[])arr;
                _out.AppendFormat(" {0} bytes [ ", arr.Length);
                for (int i = 0; i < b.Length; ++i)
                {
                    if (i != 0)
                        _out.Append(' ');
                    _out.Append(b[i].ToString("x2"));
                    if (i > _settings.MaxItems)
                    {
                        _out.Append("...");
                        break;
                    }
                }
                _out.Append(" ]");
                return;
            }
            _out.Append(" array[" + arr.Length + "] ");
            writeBrace(arr);
            processEnumerables(arr,nLevel);
        }

#endregion

        
    }

}
