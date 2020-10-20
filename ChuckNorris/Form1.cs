using ChuckNorrisAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuckNorris
{
	public partial class Form1 : Form
	{
		private IEnumerable<String> categories;

		public Form1()
		{
			InitializeComponent();
			getCategories();
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			Joke joke = await ChuckNorrisClient.GetRandomJoke();
			MessageBox.Show(joke.JokeText, "ChuckNorrisJoke");
		}

		private async void getCategories()
		{
			categories = await ChuckNorrisClient.GetCategories();
			if (categories != null)
			{
				Categories.Items.AddRange(categories.ToArray());
			}
		}
	}
}
