namespace Day08
{
    public class BootCodeFixer
    {
        public int Accumulator { get; private set; }

        public BootCodeFixer(BootCode bootCode)
        {
            if (bootCode.HadSuccessfulTermination)
            {
                Accumulator = bootCode.Accumulator;
                return;
            }

            var newInstructions = bootCode.Instructions;
            for (int i = 0; i < newInstructions.Length; i++)
            {
                var newInstruction = newInstructions[i];
                switch (newInstruction.Operation) {
                    case Consts.Jump:
                        newInstruction.Operation = Consts.NoOperation;
                        var bootCodeUpdatedNop = new BootCode(newInstructions);
                        if (bootCodeUpdatedNop.HadSuccessfulTermination)
                        {
                            Accumulator = bootCodeUpdatedNop.Accumulator;
                            return;
                        }
                        newInstruction.Operation = Consts.Jump;
                        break;
                    case Consts.NoOperation:
                        newInstruction.Operation = Consts.Jump;
                        var bootCodeUpdatedJmp = new BootCode(newInstructions);
                        if (bootCodeUpdatedJmp.HadSuccessfulTermination)
                        {
                            Accumulator = bootCodeUpdatedJmp.Accumulator;
                            return;
                        }
                        newInstruction.Operation = Consts.NoOperation;
                        break;
                }

            }
        }
    }
}
