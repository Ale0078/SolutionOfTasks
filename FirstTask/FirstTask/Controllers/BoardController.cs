using System;
using NLog;

using Task_Logic.Logic.Components.Interfaces;
using Task_Logic.UserInterface.Components.Abstracts;
using Task_Logic.Logic.Components.Builders.Abstracts;

namespace FirstTask.Controllers
{
    public class BoardController<T> : Controller<T>
    {
        private ILogger _logger;

        public BoardController(View<T> viewToDisplayBoard, BoardBuilder<T> builderToCreateBoard) 
            : base(viewToDisplayBoard, builderToCreateBoard)
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public override bool AddBoard()
        {
            ViewToDispayBoard.ViewModelsToContainBoards.AddBoard(BuildBoard());

            _logger.Info("Board was added to ViewMides");

            return true;
        }

        public override IBoard<T> BuildBoard()
        {
            try
            {
                return BuilderToCreateBoard.Create();
            }
            finally 
            {
                _logger.Info("Board was created");
            }
        }

        public override void SetBoardToBuilder(BoardBuilder<T> boardBuilder)
        {
            BuilderToCreateBoard = boardBuilder;

            _logger.Info("BoardBuilder was updated");
        }

        public override void Display()
        {
            if (!ViewToDispayBoard.Dispay()) 
            {
                _logger.Error("Something was wrong during displaying board");
                throw new InvalidOperationException();
            }

            _logger.Info("Board was built correct");
        }
    }
}
