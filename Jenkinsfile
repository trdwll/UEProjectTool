
pipeline {
  agent {
    node {
      label 'Windows'
    }
  }
  
  stages {

    stage('Build Release') {
      steps {
        bat "\"${tool 'MSBuild'}\" UEProjectTool.csproj /p:Configuration=Release  /p:ProductVersion=1.0.0.${currentBuild.number}"
      }
    }

    stage('Build Debug') {
      steps {
        bat "\"${tool 'MSBuild'}\" UEProjectTool.csproj /p:Configuration=Debug  /p:ProductVersion=1.0.0.${currentBuild.number}"
      }
    }

    stage('Publish') {
      when {
        branch "main"
      }
      steps {
        bat "C:\\JenkinsBuilder.exe UEProjectTool Publish \"%WORKSPACE%\""
      }
    }
  }
}
