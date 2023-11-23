using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace TextFileSaver
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string textToSave = TextBox.Text;

            if (string.IsNullOrWhiteSpace(textToSave))
            {
                MessageBox.Show("Введите текст для сохранения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый файл (*.txt)|*.txt|Документ Word (*.doc)|*.doc";
            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;

                try
                {
                    File.WriteAllText(fileName, textToSave);
                    MessageBox.Show($"Текст успешно сохранен в файл: {fileName}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Clear();
        }
    }
}