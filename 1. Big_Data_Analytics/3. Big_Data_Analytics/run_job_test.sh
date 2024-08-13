#!/bin/bash
#SBATCH --nodes=1
#SBATCH --ntasks-per-node=1
#SBATCH --cpus-per-task=10
#SBATCH --partition=test
#SBATCH --time=00:10:00
#SBATCH --mem=32G
#SBATCH --account=project_2000859
#SBATCH --output="slurm-%j.out"
#SBATCH --error="slurm-%j.err"

module purge
module load python-data
module list

set -xv
srun python3 $*

seff $SLURM_JOBID