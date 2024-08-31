using System.Diagnostics;

namespace android_tictactoe;

public partial class MainPage : ContentPage
{
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

	// Handles the click event of a counter button in the Tic Tac Toe game.
	// It updates the game state by placing the current player's mark on the clicked button,
	// switching the current player, and checking for a win condition.
	// If a win is detected, it resets the game board and displays a win alert.
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
		if (CheckForWin()){
			for (int i = 0; i < 3; i++){
				for (int j = 0; j < 3; j++){
					board[i, j] = ' ';
				}
			}
			foreach(var child in TicTacToeBoard.Children){
				if (child is Button btn){
					btn.Text = board[Grid.GetRow(btn), Grid.GetColumn(btn)].ToString();
				}
			}
			DisplayAlert("Winner", "Player " + (turn == 'X' ? "O" : "X") + " wins!", "Ok");
		}
	}
	
	// Checks the Tic Tac Toe game board for a win condition.
	// The function iterates over all possible winning combinations on the board.
	// It returns true if a win condition is met, false otherwise.
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

