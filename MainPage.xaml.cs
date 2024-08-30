using System.Diagnostics;

namespace android_tictactoe;

public partial class MainPage : ContentPage
{
	int count = 0;
	private char [,] board = new char[3,3];
	private char turn = 'X';

	public MainPage()
	{
		InitializeComponent();
		for (int i = 0; i < 3; i++){
			for (int j = 0; j < 3; j++){
				board[i, j] = ' ';
			}
		}
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		int row = Grid.GetRow(button);
		int col = Grid.GetColumn(button);
		if (board[row, col] == ' '){
			board[row, col] = turn;
			button.Text = turn.ToString();
			if (turn == 'X'){
				turn = 'O';
			}else{
				turn = 'X';
			}
		}
	}
	
	private bool CheckForWin()
	{
		if(board[0,0] == board[0,1] && board[0,1] == board[0,2] && board[0,0] != ' '){
			return true;
		}
		if(board[1,0] == board[1,1] && board[1,1] == board[1,2] && board[1,0] != ' '){
			return true;
		}
		if(board[2,0] == board[2,1] && board[2,1] == board[2,2] && board[2,0] != ' '){
			return true;
		}
		if(board[0,0] == board[1,0] && board[1,0] == board[2,0] && board[0,0] != ' '){
			return true;
		}
		if(board[0,1] == board[1,1] && board[1,1] == board[2,1] && board[0,1] != ' '){
			return true;
		}
		if(board[0,2] == board[1,2] && board[1,2] == board[2,2] && board[0,2] != ' '){
			return true;
		}
		if(board[0,0] == board[1,1] && board[1,1] == board[2,2] && board[0,0] != ' '){
			return true;
		}
		if(board[0,2] == board[1,1] && board[1,1] == board[2,0] && board[0,2] != ' '){
			return true;
		}
		return false;
	}
}

