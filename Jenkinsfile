
pipeline {
  agent {
    node {
      label 'Windows'
    }
  }
  
  stages {

    stage('Build Release') {
      steps {
        bat "\"${tool 'MSBuild'}\" UEProjectTool.csproj /p:Configuration=Release"
      }
    }

    stage('Build Debug') {
      steps {
        bat "\"${tool 'MSBuild'}\" UEProjectTool.csproj /p:Configuration=Debug"
      }
    }

    stage('Publish') {
      when {
        branch "main"
      }
      steps {
        bat "py -u C:\\jenkins.py UEProjectTool Publish \"%WORKSPACE%\""
      }
    }
  }
}
