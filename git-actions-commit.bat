@ECHO OFF

SET /p DESCRIPTION="Por gentileza, informe o nome do commit desejado: "

@ECHO %DESCRIPTION%

git add .
git commit -m "%DESCRIPTION%"
git push

PAUSE