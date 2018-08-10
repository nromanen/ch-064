pipeline {
  agent {
    node {
      label 'master'
    }

  }
  stages {
    stage('Git checkout') {
      steps {
        git(url: 'https://github.com/nromanen/ch-064', branch: 'DatabaseHelper')
      }
    }
    stage('Restore NuGet packages') {
      steps {
        bat(script: '"C:/Program Files (x86)/Jenkins/tools/nuget.exe" restore OnlineExamTest.sln', returnStatus: true, returnStdout: true)
      }
    }
    stage('Build project') {
      steps {
        bat(script: '\\"${tool \'MSBuildLocal\'}\\" OnlineExamTest.sln /p:Configuration=Debug /p:Platform=\\"Any CPU\\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}', returnStatus: true, returnStdout: true)
      }
    }
  }
}
