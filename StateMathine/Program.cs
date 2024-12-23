using System.ComponentModel.Design;

namespace StateMathine
{

    public enum ProcessState
    {
        Inactive,//待机状态
        Active,//运行状态
        Paused,//暂停状态
        Terminated,//终止状态
        None//未知状态
    }

    public enum Command
    {
        Begin,//开始命令
        End,//结束命令
        Pause,//暂停命令
        Resume,//恢复命令
        Exit//退出命令
    }


    public class Process
    {
        class StateTransition
        {
            readonly ProcessState _currentState;
            readonly Command _command;

            public StateTransition(ProcessState currentState, Command command)
            {
                _currentState = currentState;
                _command = command;
            }

            public override int GetHashCode()
            {
                return 17 + 31 * _currentState.GetHashCode() + 31 * _command.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                StateTransition other = obj as StateTransition;
                if (other == null) return false;
                return _currentState == other._currentState && _command == other._command;

            }

        }

        Dictionary<StateTransition, ProcessState> transitions;
        public ProcessState CurrentState { get; private set; }

        public Process()
        {
            CurrentState = ProcessState.Inactive;
            transitions = new Dictionary<StateTransition, ProcessState>();
            transitions.Add(new StateTransition(ProcessState.Inactive, Command.Begin), ProcessState.Active);
            transitions.Add(new StateTransition(ProcessState.Inactive, Command.Exit), ProcessState.Terminated);
            transitions.Add(new StateTransition(ProcessState.Active, Command.End), ProcessState.Inactive);
            transitions.Add(new StateTransition(ProcessState.Active, Command.Pause), ProcessState.Paused);
            transitions.Add(new StateTransition(ProcessState.Paused, Command.Resume), ProcessState.Active);
            transitions.Add(new StateTransition(ProcessState.Paused, Command.End), ProcessState.Terminated);
        }

        private ProcessState GetNextState(Command command)
        {
            StateTransition transition = new StateTransition(CurrentState, command);
            ProcessState nextState;
            bool found = transitions.TryGetValue(transition, out nextState);
            if (found)
            {
                return nextState;
            }
            return ProcessState.None;
        }

        public ProcessState MoveNext(Command command)
        {
            ProcessState nextState = GetNextState(command);
            if (nextState != ProcessState.None)
            {
                CurrentState = nextState;
            }
            return CurrentState;
        }

    }

    class WorkFlow
    {

        public enum TaskState
        {
            Ready,//准备状态
            Running,//运行状态
            Paused,//暂停状态
            Terminated//终止状态
        }


        public enum TaskType
        {
            Working,
            Waiting
        }
        class TaskInfo
        {

            /// <summary>
            /// 任务类型
            /// </summary>
            public TaskType taskType { get; set; }

            /// <summary>
            /// 任务工作参数
            /// </summary>
            public int WorkParam { get; set; }

            /// <summary>
            /// 任务休眠时长
            /// </summary>
            public int SleepDuration { get; set; }


        }

        private List<TaskInfo> taskList;
        private int currentTaskIndex;
        private TaskState currentTaskState;

        class Railwayer
        {
            private bool IsRunning { get; set; }

            public void Run(int workParam)
            {
                IsRunning = true;
                Thread.Sleep(workParam * 1000);
                IsRunning = false;
            }

            public bool GetRunningStatus()
            {
                Thread.Sleep(200);
                return IsRunning;
            }
        }

        private Railwayer railwayer;


        private readonly System.Threading.EventWaitHandle waitHandle = new System.Threading.AutoResetEvent(false);
        public WorkFlow()
        {
            currentTaskIndex = 0;
            railwayer = new Railwayer();
            currentTaskState = TaskState.Ready;
            taskList = new List<TaskInfo>();
            taskList.Add(new TaskInfo() { taskType = TaskType.Working, WorkParam = 5 });
            taskList.Add(new TaskInfo() { taskType = TaskType.Waiting, SleepDuration = 10 });
            taskList.Add(new TaskInfo() { taskType = TaskType.Working, WorkParam = 5 });
            taskList.Add(new TaskInfo() { taskType = TaskType.Waiting, SleepDuration = 20 });
        }

        public void Start()
        {
            currentTaskState = TaskState.Running;
            Task.Run(RailwayerRun);
        }
        public void Pause()
        {
            currentTaskState = TaskState.Paused;
        }

        public void Resume()
        {
            currentTaskState = TaskState.Running;
            Task.Run(RailwayerRun);
        }

        public void End()
        {
            currentTaskState = TaskState.Ready;
        }

        private void RailwayerRun()
        {
            while (currentTaskState == TaskState.Running)
            {
                ExecuteTask();
                Next();
            }
        }

        private void ExecuteTask()
        {
            TaskInfo taskInfo = taskList[currentTaskIndex];
            if (taskInfo.taskType == TaskType.Working)
            {
                railwayer.Run(taskInfo.WorkParam);
                //判断导轨是否静止，如果静止，则开始下一个任务
                Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(10);
                        if (currentTaskState != TaskState.Running || !railwayer.GetRunningStatus())
                        {
                            waitHandle.Set();
                            break;
                        }
                    }
                });
                waitHandle.WaitOne(10 * 1000);
            }
            else if (taskInfo.taskType == TaskType.Waiting)
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(10);
                        if (currentTaskState != TaskState.Running)
                        {
                            waitHandle.Set();
                        }
                    }
                });

                waitHandle.WaitOne(taskInfo.SleepDuration * 1000);
            }
        }

        private void Next()
        {
            currentTaskIndex++;
            if (currentTaskIndex >= taskList.Count)
            {
                currentTaskIndex = 0;
            }
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {


        }
    }
}
