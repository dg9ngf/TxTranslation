﻿// TxLib – Tx Translation & Localisation for .NET and WPF
// © Yves Goergen, Made in Germany
// Website: http://unclassified.software/source/txtranslation
//
// This library is free software: you can redistribute it and/or modify it under the terms of
// the GNU Lesser General Public License as published by the Free Software Foundation, version 3.
//
// This library is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License along with this
// library. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Threading;

namespace Unclassified.TxLib
{
	#region Text translation markup extensions

	/// <summary>
	/// Markup extension providing the Tx.T method functionality.
	/// </summary>
	public class TExtension : MarkupExtension
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the TExtension class.
		/// </summary>
		public TExtension()
		{
			Count = -1;
		}

		/// <summary>
		/// Initialises a new instance of the TExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		public TExtension(string key)
		{
			Key = key;
			Count = -1;
		}

		/// <summary>
		/// Initialises a new instance of the TExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		public TExtension(string key, int count)
		{
			Key = key;
			Count = count;
		}

		/// <summary>
		/// Initialises a new instance of the TExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="countBinding">Binding that provides the count value to consider when selecting the text value.</param>
		public TExtension(string key, Binding countBinding)
		{
			Key = key;
			CountBinding = countBinding;
			Count = -1;
		}

		/// <summary>
		/// Initialises a new instance of the TExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name = "placeholderKey1" > The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public TExtension(string key, string placeholderKey1, Binding placeholder1)
        {
			Key = key;
			Count = -1;
			PlaceholderKey1 = placeholderKey1;
			PlaceholderBinding1 = placeholder1;
        }

		/// <summary>
		/// Initialises a new instance of the TExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public TExtension(string key, int count, string placeholderKey1, Binding placeholder1)
        {
			Key = key;
			Count = count;
			PlaceholderKey1 = placeholderKey1;
			PlaceholderBinding1 = placeholder1;
		}

		/// <summary>
		/// Initialises a new instance of the TExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public TExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
		{
			Key = key;
			Count = -1;
			PlaceholderKey1 = placeholderKey1;
			PlaceholderBinding1 = placeholder1;
			PlaceholderKey2 = placeholderKey2;
			PlaceholderBinding2 = placeholder2;
		}

		/// <summary>
		/// Initialises a new instance of the TExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public TExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
		{
			Key = key;
			Count = count;
			PlaceholderKey1 = placeholderKey1;
			PlaceholderBinding1 = placeholder1;
			PlaceholderKey2 = placeholderKey2;
			PlaceholderBinding2 = placeholder2;
		}

		/// <summary>
		/// Initialises a new instance of the TExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public TExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
		{
			Key = key;
			Count = -1;
			PlaceholderKey1 = placeholderKey1;
			PlaceholderBinding1 = placeholder1;
			PlaceholderKey2 = placeholderKey2;
			PlaceholderBinding2 = placeholder2;
			PlaceholderKey3 = placeholderKey3;
			PlaceholderBinding3 = placeholder3;
		}

		/// <summary>
		/// Initialises a new instance of the TExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public TExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
		{
			Key = key;
			Count = count;
			PlaceholderKey1 = placeholderKey1;
			PlaceholderBinding1 = placeholder1;
			PlaceholderKey2 = placeholderKey2;
			PlaceholderBinding2 = placeholder2;
			PlaceholderKey3 = placeholderKey3;
			PlaceholderBinding3 = placeholder3;
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets or sets the text key to translate.
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// Gets or sets the count value to consider when selecting the text value.
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Gets or sets the binding that provides the count value to consider when selecting the text value.
		/// </summary>
		public BindingBase CountBinding { get; set; }

		/// <summary>
		/// Gets or sets the name of placeholder one.
		/// </summary>
		public string PlaceholderKey1 { get; set; }

		/// <summary>
		/// Gets or sets the binding that provides the placeholder one value to use when templating the translation.
		/// </summary>
		public BindingBase PlaceholderBinding1 { get; set; }

		/// <summary>
		/// Gets or sets the name of placeholder two.
		/// </summary>
		public string PlaceholderKey2 { get; set; }

		/// <summary>
		/// Gets or sets the binding that provides the placeholder two value to use when templating the translation.
		/// </summary>
		public BindingBase PlaceholderBinding2 { get; set; }

		/// <summary>
		/// Gets or sets the name of placeholder three.
		/// </summary>
		public string PlaceholderKey3 { get; set; }

		/// <summary>
		/// Gets or sets the binding that provides the placeholder three value to use when templating the translation.
		/// </summary>
		public BindingBase PlaceholderBinding3 { get; set; }

		/// <summary>
		/// Gets or sets the default text to display at design time.
		/// </summary>
		public string Default { get; set; }

		#endregion Properties

		#region Converter action

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected virtual Func<string, int, string> GetTFuncCount()
		{
			return Tx.T;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected virtual Func<string, string[], string> GetTFuncPlaceholders()
        {
			return Tx.T;
        }

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected virtual Func<string, int, string[], string> GetTFuncCountAndPlaceholders()
        {
			return Tx.T;
        }

		#endregion Converter action

		#region MarkupExtension overrides

		/// <summary>
		/// Provides the value of the converter.
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if (string.IsNullOrEmpty(Key))
				throw new ArgumentException("Key is not specified.", "Key");

			// Always create a dummy binding to be notified when the translation dictionary changes.
			Binding binding = new Binding("Dummy");
			binding.Source = DictionaryWatcher.Instance;
			binding.Mode = BindingMode.OneWay;

			var bindCount = CountBinding != null;
			var bindPlaceholder1 = PlaceholderBinding1 != null;
			var bindPlaceholder2 = bindPlaceholder1 && PlaceholderBinding2 != null;
			var bindPlaceholder3 = bindPlaceholder2 && PlaceholderBinding3 != null;
			var bindPlaceholders = bindPlaceholder1;

			if (bindPlaceholder1 && string.IsNullOrEmpty(PlaceholderKey1))
				throw new ArgumentException("Placeholder key 1 is not specified");

			if (bindPlaceholder2 && string.IsNullOrEmpty(PlaceholderKey2))
				throw new ArgumentException("Placeholder key 2 is not specified");

			if (bindPlaceholder3 && string.IsNullOrEmpty(PlaceholderKey3))
				throw new ArgumentException("Placeholder key 3 is not specified");

			if (bindCount || bindPlaceholders)
            {
				// Optional bindings have been set, so multiple bindings need to be combined.
				MultiBinding multiBinding = new MultiBinding();
				multiBinding.Mode = BindingMode.TwoWay;

				// Add the dummy binding as well as the binding for the count value.
				multiBinding.Bindings.Add(binding);
				if (bindCount) multiBinding.Bindings.Add(CountBinding);
				if (bindPlaceholder1) multiBinding.Bindings.Add(PlaceholderBinding1);
				if (bindPlaceholder2) multiBinding.Bindings.Add(PlaceholderBinding2);
				if (bindPlaceholder3) multiBinding.Bindings.Add(PlaceholderBinding3);

				// The converter will invoke the actual translation of the key and additional data.
				if (bindCount && !bindPlaceholders)
                {
					multiBinding.Converter = new TConverter(GetTFuncCount(), Key, Default);
					return multiBinding.ProvideValue(serviceProvider);
				}
				else if (!bindCount && bindPlaceholders)
                {
					var placeholder_keys = new string[] { PlaceholderKey1, PlaceholderKey2, PlaceholderKey3 }.Where(s => s != null).ToArray();
					multiBinding.Converter = new TConverter(GetTFuncPlaceholders(), Key, placeholder_keys, Default);
					return multiBinding.ProvideValue(serviceProvider);
                }
				else
                {
					var placeholder_keys = new string[] { PlaceholderKey1, PlaceholderKey2, PlaceholderKey3 }.Where(s => s != null).ToArray();
					multiBinding.Converter = new TConverter(GetTFuncCountAndPlaceholders(), Key, Count, placeholder_keys, Default);
					return multiBinding.ProvideValue(serviceProvider);
				}
			}
            else
            {
				// No optional binding, so a simple binding will do.

				// The converter will invoke the actual translation of the key and additional data.
				binding.Converter = new TConverter(GetTFuncCount(), Key, Count, Default);
				return binding.ProvideValue(serviceProvider);
			}

			//if (CountBinding != null)
			//{
			//	// A CountBinding has been set, so multiple bindings need to be combined.
			//	MultiBinding multiBinding = new MultiBinding();
			//	multiBinding.Mode = BindingMode.TwoWay;

			//	// Add the dummy binding as well as the binding for the count value.
			//	multiBinding.Bindings.Add(binding);
			//	multiBinding.Bindings.Add(CountBinding);

			//	// The converter will invoke the actual translation of the key and additional data.
			//	multiBinding.Converter = new TConverter(GetTFuncCount(), Key, Default);
			//	return multiBinding.ProvideValue(serviceProvider);
			//}
			//else
			//{
			//	// No CountBinding, so a simple binding will do.

			//	// The converter will invoke the actual translation of the key and additional data.
			//	binding.Converter = new TConverter(GetTFuncCount(), Key, Count, Default);
			//	return binding.ProvideValue(serviceProvider);
			//}
		}

		#endregion MarkupExtension overrides
	}

	/// <summary>
	/// Markup extension providing the Tx.UT method functionality.
	/// </summary>
	public class UTExtension : TExtension
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the UTExtension class.
		/// </summary>
		public UTExtension()
			: base()
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		public UTExtension(string key)
			: base(key)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		public UTExtension(string key, int count)
			: base(key, count)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="countBinding">Binding that provides the count value to consider when selecting the text value.</param>
		public UTExtension(string key, Binding countBinding)
			: base(key, countBinding)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public UTExtension(string key, string placeholderKey1, Binding placeholder1)
			: base(key, placeholderKey1, placeholder1)
        {
        }

		/// <summary>
		/// Initialises a new instance of the UTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count"> Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public UTExtension(string key, int count, string placeholderKey1, Binding placeholder1)
			: base(key, count, placeholderKey1, placeholder1)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public UTExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count" > Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public UTExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public UTExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count" > Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public UTExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		#endregion Constructors

		#region Converter action

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string> GetTFuncCount()
		{
			return Tx.UT;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, string[], string> GetTFuncPlaceholders()
		{
			return Tx.UT;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string[], string> GetTFuncCountAndPlaceholders()
		{
			return Tx.UT;
		}

		#endregion Converter action
	}

	/// <summary>
	/// Markup extension providing the Tx.TC method functionality.
	/// </summary>
	public class TCExtension : TExtension
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the TCExtension class.
		/// </summary>
		public TCExtension()
			: base()
		{
		}

		/// <summary>
		/// Initialises a new instance of the TCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		public TCExtension(string key)
			: base(key)
		{
		}

		/// <summary>
		/// Initialises a new instance of the TCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		public TCExtension(string key, int count)
			: base(key, count)
		{
		}

		/// <summary>
		/// Initialises a new instance of the TCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="countBinding">Binding that provides the count value to consider when selecting the text value.</param>
		public TCExtension(string key, Binding countBinding)
			: base(key, countBinding)
		{
		}

		/// <summary>
		/// Initialises a new instance of the TCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public TCExtension(string key, string placeholderKey1, Binding placeholder1)
			: base(key, placeholderKey1, placeholder1)
        {
        }

		/// <summary>
		/// Initialises a new instance of the TCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public TCExtension(string key, int count, string placeholderKey1, Binding placeholder1)
			: base(key, count, placeholderKey1, placeholder1)
		{
		}

		/// <summary>
		/// Initialises a new instance of the TCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public TCExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the TCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public TCExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the TCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public TCExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		/// <summary>
		/// Initialises a new instance of the TCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public TCExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		#endregion Constructors

		#region Converter action

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string> GetTFuncCount()
		{
			return Tx.TC;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, string[], string> GetTFuncPlaceholders()
		{
			return Tx.TC;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string[], string> GetTFuncCountAndPlaceholders()
		{
			return Tx.TC;
		}

		#endregion Converter action
	}

	/// <summary>
	/// Markup extension providing the Tx.UTC method functionality.
	/// </summary>
	public class UTCExtension : TExtension
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the UTCExtension class.
		/// </summary>
		public UTCExtension()
			: base()
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		public UTCExtension(string key)
			: base(key)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		public UTCExtension(string key, int count)
			: base(key, count)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="countBinding">Binding that provides the count value to consider when selecting the text value.</param>
		public UTCExtension(string key, Binding countBinding)
			: base(key, countBinding)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTCExtension class.
		/// </summary>
		public UTCExtension(string key, string placeholderKey1, Binding placeholder1)
			: base(key, placeholderKey1, placeholder1)
        {
        }

		/// <summary>
		/// Initialises a new instance of the UTCExtension class.
		/// </summary>
		public UTCExtension(string key, int count, string placeholderKey1, Binding placeholder1)
			: base(key, count, placeholderKey1, placeholder1)
        {
        }

		/// <summary>
		/// Initialises a new instance of the UTCExtension class.
		/// </summary>
		public UTCExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTCExtension class.
		/// </summary>
		public UTCExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTCExtension class.
		/// </summary>
		public UTCExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		/// <summary>
		/// Initialises a new instance of the UTCExtension class.
		/// </summary>
		public UTCExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		#endregion Constructors

		#region Converter action

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string> GetTFuncCount()
		{
			return Tx.UTC;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, string[], string> GetTFuncPlaceholders()
		{
			return Tx.UTC;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string[], string> GetTFuncCountAndPlaceholders()
		{
			return Tx.UTC;
		}

		#endregion Converter action
	}

	/// <summary>
	/// Markup extension providing the Tx.QT method functionality.
	/// </summary>
	public class QTExtension : TExtension
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the QTExtension class.
		/// </summary>
		public QTExtension()
			: base()
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		public QTExtension(string key)
			: base(key)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		public QTExtension(string key, int count)
			: base(key, count)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="countBinding">Binding that provides the count value to consider when selecting the text value.</param>
		public QTExtension(string key, Binding countBinding)
			: base(key, countBinding)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public QTExtension(string key, string placeholderKey1, Binding placeholder1)
			: base(key, placeholderKey1, placeholder1)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public QTExtension(string key, int count, string placeholderKey1, Binding placeholder1)
			: base(key, count, placeholderKey1, placeholder1)
        {
        }

		/// <summary>
		/// Initialises a new instance of the QTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public QTExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public QTExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public QTExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public QTExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		#endregion Constructors

		#region Converter action

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string> GetTFuncCount()
		{
			return Tx.QT;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, string[], string> GetTFuncPlaceholders()
		{
			return Tx.QT;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string[], string> GetTFuncCountAndPlaceholders()
		{
			return Tx.QT;
		}

		#endregion Converter action
	}

	/// <summary>
	/// Markup extension providing the Tx.QTC method functionality.
	/// </summary>
	public class QTCExtension : TExtension
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the QTCExtension class.
		/// </summary>
		public QTCExtension()
			: base()
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		public QTCExtension(string key)
			: base(key)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		public QTCExtension(string key, int count)
			: base(key, count)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="countBinding">Binding that provides the count value to consider when selecting the text value.</param>
		public QTCExtension(string key, Binding countBinding)
			: base(key, countBinding)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public QTCExtension(string key, string placeholderKey1, Binding placeholder1)
			: base(key, placeholderKey1, placeholder1)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public QTCExtension(string key, int count, string placeholderKey1, Binding placeholder1)
			: base(key, count, placeholderKey1, placeholder1)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public QTCExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public QTCExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public QTCExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public QTCExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		#endregion Constructors

		#region Converter action

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string> GetTFuncCount()
		{
			return Tx.QTC;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, string[], string> GetTFuncPlaceholders()
		{
			return Tx.QTC;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string[], string> GetTFuncCountAndPlaceholders()
		{
			return Tx.QTC;
		}

		#endregion Converter action
	}

	/// <summary>
	/// Markup extension providing the Tx.QUT method functionality.
	/// </summary>
	public class QUTExtension : TExtension
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the QUTExtension class.
		/// </summary>
		public QUTExtension()
			: base()
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		public QUTExtension(string key)
			: base(key)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		public QUTExtension(string key, int count)
			: base(key, count)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="countBinding">Binding that provides the count value to consider when selecting the text value.</param>
		public QUTExtension(string key, Binding countBinding)
			: base(key, countBinding)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public QUTExtension(string key, string placeholderKey1, Binding placeholder1)
			: base(key, placeholderKey1, placeholder1)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public QUTExtension(string key, int count, string placeholderKey1, Binding placeholder1)
			: base(key, count, placeholderKey1, placeholder1)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public QUTExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public QUTExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public QUTExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public QUTExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		#endregion Constructors

		#region Converter action

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string> GetTFuncCount()
		{
			return Tx.QUT;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, string[], string> GetTFuncPlaceholders()
		{
			return Tx.QUT;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string[], string> GetTFuncCountAndPlaceholders()
		{
			return Tx.QUT;
		}

		#endregion Converter action
	}

	/// <summary>
	/// Markup extension providing the Tx.QUTC method functionality.
	/// </summary>
	public class QUTCExtension : TExtension
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the QUTCExtension class.
		/// </summary>
		public QUTCExtension()
			: base()
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		public QUTCExtension(string key)
			: base(key)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		public QUTCExtension(string key, int count)
			: base(key, count)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="countBinding">Binding that provides the count value to consider when selecting the text value.</param>
		public QUTCExtension(string key, Binding countBinding)
			: base(key, countBinding)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public QUTCExtension(string key, string placeholderKey1, Binding placeholder1)
			: base(key, placeholderKey1, placeholder1)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		public QUTCExtension(string key, int count, string placeholderKey1, Binding placeholder1)
			: base(key, count, placeholderKey1, placeholder1)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public QUTCExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		public QUTCExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public QUTCExtension(string key, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		/// <summary>
		/// Initialises a new instance of the QUTCExtension class.
		/// </summary>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholderKey1">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder1">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey2">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder2">The value binding to replace the placeholder when templating.</param>
		/// <param name="placeholderKey3">The name of the placeholder in the localization resource.</param>
		/// <param name="placeholder3">The value binding to replace the placeholder when templating.</param>
		public QUTCExtension(string key, int count, string placeholderKey1, Binding placeholder1, string placeholderKey2, Binding placeholder2, string placeholderKey3, Binding placeholder3)
			: base(key, count, placeholderKey1, placeholder1, placeholderKey2, placeholder2, placeholderKey3, placeholder3)
		{
		}

		#endregion Constructors

		#region Converter action

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string> GetTFuncCount()
		{
			return Tx.QUTC;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, string[], string> GetTFuncPlaceholders()
		{
			return Tx.QUTC;
		}

		/// <summary>
		/// Provides the T method in specialised classes.
		/// </summary>
		/// <returns></returns>
		protected override Func<string, int, string[], string> GetTFuncCountAndPlaceholders()
		{
			return Tx.QUTC;
		}

		#endregion Converter action
	}

	#endregion Text translation markup extensions

	#region Number formatting markup extensions

	/// <summary>
	/// Markup extension providing the Tx.Number method functionality.
	/// </summary>
	public class NumberExtension : MarkupExtension
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the NumberExtension class.
		/// </summary>
		public NumberExtension()
		{
			Decimals = -1;
		}

		/// <summary>
		/// Initialises a new instance of the NumberExtension class.
		/// </summary>
		/// <param name="numberBinding">Binding that provides the number value to format.</param>
		public NumberExtension(Binding numberBinding)
		{
			NumberBinding = numberBinding;
			Decimals = -1;
		}

		/// <summary>
		/// Initialises a new instance of the NumberExtension class.
		/// </summary>
		/// <param name="numberBinding">Binding that provides the number value to format.</param>
		/// <param name="decimals">Number of decimal digits to format.</param>
		public NumberExtension(Binding numberBinding, int decimals)
		{
			NumberBinding = numberBinding;
			Decimals = decimals;
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets or sets the binding that provides the number value to format.
		/// </summary>
		public Binding NumberBinding { get; set; }

		/// <summary>
		/// Gets or sets the number of decimal digits to format.
		/// </summary>
		public int Decimals { get; set; }

		/// <summary>
		/// Gets or sets the unit to append to the number.
		/// </summary>
		public string Unit { get; set; }

		#endregion Properties

		#region MarkupExtension overrides

		/// <summary>
		/// Provides the value of the converter.
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if (NumberBinding == null)
				throw new ArgumentNullException("NumberBinding");

			// Always create a dummy binding to be notified when the translation dictionary changes.
			Binding binding = new Binding("Dummy");
			binding.Source = DictionaryWatcher.Instance;
			binding.Mode = BindingMode.OneWay;

			MultiBinding multiBinding = new MultiBinding();
			multiBinding.Mode = BindingMode.TwoWay;

			// Add the dummy binding as well as the binding for the number value.
			multiBinding.Bindings.Add(binding);
			multiBinding.Bindings.Add(NumberBinding);

			// The converter will invoke the actual formatting of the value.
			multiBinding.Converter = new NConverter(Decimals, Unit);
			return multiBinding.ProvideValue(serviceProvider);
		}

		#endregion MarkupExtension overrides
	}

	/// <summary>
	/// Markup extension providing the Tx.DataSize method functionality.
	/// </summary>
	public class DataSizeExtension : MarkupExtension
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the DataSizeExtension class.
		/// </summary>
		public DataSizeExtension()
		{
		}

		/// <summary>
		/// Initialises a new instance of the DataSizeExtension class.
		/// </summary>
		/// <param name="numberBinding">Binding that provides the number value to format.</param>
		public DataSizeExtension(Binding numberBinding)
		{
			NumberBinding = numberBinding;
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets or sets the binding that provides the number value to format.
		/// </summary>
		public Binding NumberBinding { get; set; }

		#endregion Properties

		#region MarkupExtension overrides

		/// <summary>
		/// Provides the value of the converter.
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if (NumberBinding == null)
				throw new ArgumentNullException("NumberBinding");

			// Always create a dummy binding to be notified when the translation dictionary changes.
			Binding binding = new Binding("Dummy");
			binding.Source = DictionaryWatcher.Instance;
			binding.Mode = BindingMode.OneWay;

			MultiBinding multiBinding = new MultiBinding();
			multiBinding.Mode = BindingMode.TwoWay;

			// Add the dummy binding as well as the binding for the number value.
			multiBinding.Bindings.Add(binding);
			multiBinding.Bindings.Add(NumberBinding);

			// The converter will invoke the actual formatting of the value.
			multiBinding.Converter = new DSConverter();
			return multiBinding.ProvideValue(serviceProvider);
		}

		#endregion MarkupExtension overrides
	}

	#endregion Number formatting markup extensions

	#region Date and time formatting markup extensions

	/// <summary>
	/// Markup extension providing the Tx.Time method functionality.
	/// </summary>
	public class TimeExtension : MarkupExtension
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the TimeExtension class.
		/// </summary>
		public TimeExtension()
		{
			Details = TxTime.YearMonthDay;
		}

		/// <summary>
		/// Initialises a new instance of the TimeExtension class.
		/// </summary>
		/// <param name="timeBinding">Binding that provides the time value to format.</param>
		public TimeExtension(Binding timeBinding)
		{
			TimeBinding = timeBinding;
			Details = TxTime.YearMonthDay;
		}

		/// <summary>
		/// Initialises a new instance of the TimeExtension class.
		/// </summary>
		/// <param name="timeBinding">Binding that provides the time value to format.</param>
		/// <param name="details">Details to include in the formatted string.</param>
		public TimeExtension(Binding timeBinding, TxTime details)
		{
			TimeBinding = timeBinding;
			Details = details;
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets or sets the binding that provides the time value to format.
		/// </summary>
		public Binding TimeBinding { get; set; }

		/// <summary>
		/// Gets or sets the details to include in the formatted string.
		/// </summary>
		public TxTime Details { get; set; }

		#endregion Properties

		#region MarkupExtension overrides

		/// <summary>
		/// Provides the value of the converter.
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if (TimeBinding == null)
				throw new ArgumentNullException("TimeBinding");

			// Always create a dummy binding to be notified when the translation dictionary changes.
			Binding binding = new Binding("Dummy");
			binding.Source = DictionaryWatcher.Instance;
			binding.Mode = BindingMode.OneWay;

			MultiBinding multiBinding = new MultiBinding();
			multiBinding.Mode = BindingMode.TwoWay;

			// Add the dummy binding as well as the binding for the number value.
			multiBinding.Bindings.Add(binding);
			multiBinding.Bindings.Add(binding);   // We don't have a timer binding here but need to fill the slot
			multiBinding.Bindings.Add(TimeBinding);

			// The converter will invoke the actual formatting of the value.
			multiBinding.Converter = new TimeConverter(Details);
			return multiBinding.ProvideValue(serviceProvider);
		}

		#endregion MarkupExtension overrides
	}

	/// <summary>
	/// Markup extension providing the Tx.RelativeTime method functionality.
	/// </summary>
	public class RelativeTimeExtension : MarkupExtension
	{
		#region Constructors

		/// <summary>
		/// Initialises a new instance of the RelativeTimeExtension class.
		/// </summary>
		public RelativeTimeExtension()
		{
			RelativeTimeKind = TxLib.RelativeTimeKind.PointInTime;
		}

		/// <summary>
		/// Initialises a new instance of the RelativeTimeExtension class.
		/// </summary>
		/// <param name="timeBinding">Binding that provides the time value to format.</param>
		public RelativeTimeExtension(Binding timeBinding)
		{
			TimeBinding = timeBinding;
			RelativeTimeKind = TxLib.RelativeTimeKind.PointInTime;
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets or sets the binding that provides the time value to format.
		/// </summary>
		public Binding TimeBinding { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the first letter is transformed to upper case.
		/// </summary>
		public bool UpperCase { get; set; }

		/// <summary>
		/// Gets or sets the relative time kind.
		/// </summary>
		public RelativeTimeKind RelativeTimeKind { get; set; }

		#endregion Properties

		#region MarkupExtension overrides

		/// <summary>
		/// Provides the value of the converter.
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if (TimeBinding == null)
				throw new ArgumentNullException("TimeBinding");

			// Always create a dummy binding to be notified when the translation dictionary changes.
			Binding binding = new Binding("Dummy");
			binding.Source = DictionaryWatcher.Instance;
			binding.Mode = BindingMode.OneWay;

			Binding timerBinding = new Binding("Dummy");
			timerBinding.Source = UpdateTimer.Instance;
			timerBinding.Mode = BindingMode.OneWay;

			MultiBinding multiBinding = new MultiBinding();
			multiBinding.Mode = BindingMode.TwoWay;

			// Add the dummy binding as well as the binding for the number value.
			multiBinding.Bindings.Add(binding);
			multiBinding.Bindings.Add(timerBinding);
			multiBinding.Bindings.Add(TimeBinding);

			// The converter will invoke the actual formatting of the value.
			multiBinding.Converter = new TimeConverter(RelativeTimeKind, UpperCase);
			return multiBinding.ProvideValue(serviceProvider);
		}

		#endregion MarkupExtension overrides
	}

	#endregion Date and time formatting markup extensions

	#region Helper classes

	/// <summary>
	/// Dummy class to provide notifications when the dictionary has changed.
	/// </summary>
	internal class DictionaryWatcher : INotifyPropertyChanged
	{
		#region Static singleton access

		private static DictionaryWatcher instance;
		internal static DictionaryWatcher Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DictionaryWatcher();
				}
				return instance;
			}
		}

		#endregion Static singleton access

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion Events

		#region Constructors

		private DictionaryWatcher()
		{
			Tx.DictionaryChanged += delegate (object sender, EventArgs args)
			{
				var handler = PropertyChanged;
				if (handler != null)
				{
					handler(this, new PropertyChangedEventArgs("Dummy"));
				}
			};
		}

		#endregion Constructors

		#region Properties

		public int Dummy
		{
			get { return 0; }
		}

		#endregion Properties
	}

	/// <summary>
	/// Converts the various binding values to a translated text string.
	/// </summary>
	internal class TConverter : IValueConverter, IMultiValueConverter
	{
		#region Private fields

		private string key;
		private int count;
		private string[] placeholder_keys;
		private object tFunc;
		private string defaultValue;

		#endregion Private fields

		#region Constructors

		/// <summary>
		/// Initialises a new instance of the TConverter class.
		/// </summary>
		/// <param name="tFunc"></param>
		/// <param name="key">Text key to translate.</param>
		/// <param name="defaultValue">Default text to display at design time.</param>
		public TConverter(Func<string, int, string> tFunc, string key, string defaultValue)
		{
			this.tFunc = tFunc;
			this.key = key;
			this.count = -1;
			this.defaultValue = defaultValue;
		}

		/// <summary>
		/// Initialises a new instance of the TConverter class.
		/// </summary>
		/// <param name="tFunc"></param>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="defaultValue">Default text to display at design time.</param>
		public TConverter(Func<string, int, string> tFunc, string key, int count, string defaultValue)
		{
			this.tFunc = tFunc;
			this.key = key;
			this.count = count;
			this.defaultValue = defaultValue;
		}

		/// <summary>
		/// Initialises a new instance of the TConverter class.
		/// </summary>
		/// <param name="tFunc"></param>
		/// <param name="key">Text key to translate.</param>
		/// <param name="placeholder_keys">Placeholders key and values data.</param>
		/// <param name="defaultValue">Default text to display at design time.</param>
		public TConverter(Func<string, string[], string> tFunc, string key, string[] placeholder_keys, string defaultValue)
        {
			this.tFunc = tFunc;
			this.key = key;
			this.placeholder_keys = placeholder_keys;
			this.count = -1;
			this.defaultValue = defaultValue;
        }

		/// <summary>
		/// Initialises a new instance of the TConverter class.
		/// </summary>
		/// <param name="tFunc"></param>
		/// <param name="key">Text key to translate.</param>
		/// <param name="count">Count value to consider when selecting the text value.</param>
		/// <param name="placeholder_keys">Placeholders keys.</param>
		/// <param name="defaultValue">Default text to display at design time.</param>
		public TConverter(Func<string, int, string[], string> tFunc, string key, int count, string[] placeholder_keys, string defaultValue)
        {
			this.tFunc = tFunc;
			this.key = key;
			this.placeholder_keys = placeholder_keys;
			this.count = count;
			this.defaultValue = defaultValue;
        }

		#endregion Constructors

		#region IValueConverter members

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// Return the text key only in design mode. Nothing better to do for now.
			if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
			{
				return defaultValue ?? key;
			}

			// value is the Dummy binding, don't use it

			// Now translate the text and return the result.
			if (tFunc is Func<string, int, string> tFunc_str_int)
				return tFunc_str_int(key, count);
			if (tFunc is Func<string, string[], string> tFunc_str_strArr)
				return tFunc_str_strArr(key, placeholder_keys);
			if (tFunc is Func<string, int, string[], string> tFunc_str_int_strArr)
				return tFunc_str_int_strArr(key, count, placeholder_keys);

			// shouldn't reach here
			return defaultValue ?? key;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return Binding.DoNothing;
		}

		#endregion IValueConverter members

		#region IMultiValueConverter members

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// Return the text key only in design mode. Nothing better to do for now.
			if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
			{
				return defaultValue ?? key;
			}

			// values[0] is the Dummy binding, don't use it
			values = values.Skip(1).ToArray();

			// Now translate the text and return the result.
			if (tFunc is Func<string, int, string> tFunc_string_int)
            {
				// read the count value
				if (values[0] != DependencyProperty.UnsetValue)
					count = System.Convert.ToInt32(values[0]);
				return tFunc_string_int(key, count);
			}
			if (tFunc is Func<string, string[], string> tFunc_string_stringArr)
            {
				// read the bound parameter values
				values = values.Where(v => v != DependencyProperty.UnsetValue).ToArray();
				var args = JoinKeyValuePairs(placeholder_keys, values).ToArray();
				return tFunc_string_stringArr(key, args);
            }
			if (tFunc is Func<string, int, string[], string> tFunc_string_int_stringArr)
            {
				// read the count value
				if (values[0] != DependencyProperty.UnsetValue)
					count = System.Convert.ToInt32(values[0]);

				// read the bound parameter values
				values = values.Where(v => v != DependencyProperty.UnsetValue).ToArray();
				var args = JoinKeyValuePairs(placeholder_keys, values).ToArray();
				return tFunc_string_int_stringArr(key, count, args);
			}
			return null;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			return new object[0];
		}

		private IEnumerable<string> JoinKeyValuePairs(IEnumerable<string> keys, IEnumerable<object> values)
        {
			var iter_keys = keys.GetEnumerator();
			var iter_values = values.GetEnumerator();

			while (iter_keys.MoveNext() && iter_values.MoveNext())
            {
				yield return iter_keys.Current;
				yield return iter_values.Current as string;
            }
        }

		#endregion IMultiValueConverter members
	}

	/// <summary>
	/// Converts the number binding value to a formatted number.
	/// </summary>
	internal class NConverter : IMultiValueConverter
	{
		#region Private fields

		private int decimals;
		private string unit;

		#endregion Private fields

		#region Constructors

		/// <summary>
		/// Initialises a new instance of the NConverter class.
		/// </summary>
		/// <param name="decimals">Number of decimal digits to format.</param>
		/// <param name="unit">Unit to append to the number.</param>
		public NConverter(int decimals, string unit)
		{
			this.decimals = decimals;
			this.unit = unit;
		}

		#endregion Constructors

		#region IMultiValueConverter members

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string number;

			// Return the text key only in design mode. Nothing better to do for now.
			if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
			{
				if (decimals > -1)
				{
					number = Tx.Number(0, decimals);
				}
				else
				{
					number = Tx.Number(0);
				}
			}
			else
			{
				// values[0] is the Dummy binding, don't use it

				// Read the number value from binding number two.
				if (values[1] == DependencyProperty.UnsetValue)
				{
					return DependencyProperty.UnsetValue;
				}
				else if (values[1] is byte || values[1] is sbyte ||
					values[1] is ushort || values[1] is short ||
					values[1] is uint || values[1] is int ||
					values[1] is long)
				{
					long l = System.Convert.ToInt64(values[1]);
					number = Tx.Number(l);
				}
				else
				{
					decimal d = System.Convert.ToDecimal(values[1]);
					if (decimals > -1)
					{
						number = Tx.Number(d, decimals);
					}
					else
					{
						number = Tx.Number(d);
					}
				}
			}

			if (!string.IsNullOrEmpty(unit))
			{
				number = Tx.NumberUnit(number, unit);
			}

			return number;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			return new object[0];
		}

		#endregion IMultiValueConverter members
	}

	/// <summary>
	/// Converts the number binding value to a formatted data size.
	/// </summary>
	internal class DSConverter : IMultiValueConverter
	{
		#region IMultiValueConverter members

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// Return the text key only in design mode. Nothing better to do for now.
			if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
			{
				return Tx.DataSize(0);
			}

			// values[0] is the Dummy binding, don't use it

			// Read the number value from binding number two.
			if (values[1] == DependencyProperty.UnsetValue)
			{
				return DependencyProperty.UnsetValue;
			}
			long l = System.Convert.ToInt64(values[1]);
			return Tx.DataSize(l);
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			return new object[0];
		}

		#endregion IMultiValueConverter members
	}

	/// <summary>
	/// Converts the time binding value to a formatted date or time.
	/// </summary>
	internal class TimeConverter : IMultiValueConverter
	{
		#region Private fields

		private TxTime details;
		private RelativeTimeKind relKind;
		private bool upperCase;

		#endregion Private fields

		#region Constructors

		/// <summary>
		/// Initialises a new instance of the TimeConverter class for an absolute time specification.
		/// </summary>
		/// <param name="details">Details to include in the formatted string.</param>
		public TimeConverter(TxTime details)
		{
			this.relKind = RelativeTimeKind.None;
			this.details = details;
		}

		/// <summary>
		/// Initialises a new instance of the TimeConverter class for a relative time specification.
		/// </summary>
		/// <param name="relKind">Kind of relative time.</param>
		/// <param name="upperCase">A value indicating whether the first letter is transformed to upper case.</param>
		public TimeConverter(RelativeTimeKind relKind, bool upperCase)
		{
			this.relKind = relKind;
			this.upperCase = upperCase;
		}

		#endregion Constructors

		#region IMultiValueConverter members

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string text;

			// Return the text key only in design mode. Nothing better to do for now.
			if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
			{
				switch (relKind)
				{
					case RelativeTimeKind.None:
						text = Tx.Time(DateTime.Now, details);
						break;
					case RelativeTimeKind.PointInTime:
						text = Tx.RelativeTime(DateTime.Now.AddHours(2).AddMinutes(34));
						break;
					case RelativeTimeKind.CurrentTimeSpan:
						text = Tx.TimeSpan(DateTime.Now.AddHours(2).AddMinutes(34));
						break;
					case RelativeTimeKind.TimeSpan:
						text = Tx.TimeSpan(TimeSpan.FromHours(2) + TimeSpan.FromMinutes(34));
						break;
					default:
						text = "{Error: Invalid relKind}";   // Should not happen
						break;
				}
			}
			else
			{
				// values[0] is the dictionary Dummy binding, don't use it
				// values[1] is the timer Dummy binding, don't use it

				// Read the time value from binding number three.
				if (values[2] == DependencyProperty.UnsetValue)
				{
					return DependencyProperty.UnsetValue;
				}
				DateTime dt;
				TimeSpan ts;
				switch (relKind)
				{
					case RelativeTimeKind.None:
						dt = System.Convert.ToDateTime(values[2]);
						text = Tx.Time(dt, details);
						break;
					case RelativeTimeKind.PointInTime:
						dt = System.Convert.ToDateTime(values[2]);
						text = Tx.RelativeTime(dt);
						break;
					case RelativeTimeKind.CurrentTimeSpan:
						dt = System.Convert.ToDateTime(values[2]);
						text = Tx.TimeSpan(dt);
						break;
					case RelativeTimeKind.TimeSpan:
						if (values[2] is TimeSpan)
						{
							ts = (TimeSpan)values[2];
							text = Tx.TimeSpan(ts);
						}
						else
						{
							text = "";
						}
						break;
					default:
						text = "{Error: Invalid relKind}";   // Should not happen
						break;
				}
			}

			if (upperCase)
			{
				text = Tx.UpperCase(text);
			}

			return text;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			return new object[0];
		}

		#endregion IMultiValueConverter members
	}

	internal class UpdateTimer : INotifyPropertyChanged
	{
		#region Static singleton access

		private static UpdateTimer instance;
		public static UpdateTimer Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new UpdateTimer();
				}
				return instance;
			}
		}

		#endregion Static singleton access

		#region Private data

		private readonly DispatcherTimer dispatcherTimer;

		#endregion Private data

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion Events

		#region Constructors

		private UpdateTimer()
		{
			dispatcherTimer = new DispatcherTimer();
			dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
			dispatcherTimer.Start();
			dispatcherTimer.Tick += delegate (object sender, EventArgs args)
			{
				var handler = PropertyChanged;
				if (handler != null)
				{
					handler(this, new PropertyChangedEventArgs("Dummy"));
				}
			};
		}

		#endregion Constructors

		#region Properties

		public int Dummy
		{
			get { return 0; }
		}

		#endregion Properties
	}

	/// <summary>
	/// Values that specify a kind of relative time.
	/// </summary>
	[System.Reflection.Obfuscation(Exclude = true)]
	public enum RelativeTimeKind
	{
		/// <summary>
		/// No relative time.
		/// </summary>
		None,
		/// <summary>
		/// Point in time.
		/// </summary>
		PointInTime,
		/// <summary>
		/// Time span starting at the current time.
		/// </summary>
		CurrentTimeSpan,
		/// <summary>
		/// Independent time span.
		/// </summary>
		TimeSpan
	}

	#endregion Helper classes
}
