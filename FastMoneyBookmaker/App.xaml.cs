using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;

namespace FastMoneyBookmaker
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
		private static readonly List<CultureInfo> m_Languages = new List<CultureInfo>();
		public static List<CultureInfo> Languages
		{
			get
			{
				return m_Languages;
			}
		}
		public App()
		{
			m_Languages.Clear();
			m_Languages.Add(new CultureInfo("en-US")); //Нейтральная культура для этого проекта
			m_Languages.Add(new CultureInfo("ru-RU"));
			Thread.CurrentThread.CurrentUICulture = m_Languages[0];
		
		}

		public static event EventHandler LanguageChanged;

		public static CultureInfo Language
		{
			get
			{
				return System.Threading.Thread.CurrentThread.CurrentUICulture;
			}
			set
			{
				if (value == null) throw new ArgumentNullException("value");
				if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

				//1. Меняем язык приложения:
				System.Threading.Thread.CurrentThread.CurrentUICulture = value;

				//2. Создаём ResourceDictionary для новой культуры
				ResourceDictionary dict = new ResourceDictionary();
				switch (value.Name)
				{
					case "ru-RU":
						dict.Source = new Uri(String.Format("Resources/Languages/Lang.{0}.xaml", value.Name), UriKind.Relative);
						break;
					default:
						dict.Source = new Uri("Resources/Languages/Lang.xaml", UriKind.Relative);
						break;
				}

				//3. Находим старую ResourceDictionary и удаляем его и добавляем новую ResourceDictionary
				ResourceDictionary oldDict= (from d in Application.Current.Resources.MergedDictionaries
												  where d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang.")
												  select d).FirstOrDefault();
				if (oldDict != null)
				{
					int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
					Application.Current.Resources.MergedDictionaries.Remove(oldDict);
					Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
				}
				else
				{
					Application.Current.Resources.MergedDictionaries.Add(dict);
				}

				//4. Вызываем евент для оповещения всех окон.
				LanguageChanged(Application.Current, new EventArgs());
			}
		}
		
	}
}
