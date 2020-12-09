import subprocess

# passing panda executable and panda test script
# panda executable will be generated after build alongside the directory
subprocess.run(["..\\bin\\debug\\netcoreapp3.1\\Panda.exe", "..\\panda\\print_test.pd"])
