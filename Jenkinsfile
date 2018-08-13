script {
    env.STATUS_PATH = '/var/jenkins/dumb-slave-1/workspace/status/'
    env.HYPER_PATH = '/home/site/hyper/'
    env.HYPER_PID = '/var/run/hyper.pid'
    env.HYPER_SCRIPTS = '/usr/local/sbin/'
}

pipeline {
  agent {
    node {
      label 'master'
    }
  }
  stages {
    stage('SCM') {
      steps {
        checkout scm
      }
    }
    stage('Restore NuGet packages') {
      steps {
        bat(script: '"C:/Program Files (x86)/Jenkins/tools/nuget.exe" restore OnlineExamTest.sln', returnStatus: true, returnStdout: true)
      }
    }
    stage('Build') {
      steps {
        bat "\"${tool 'MSBuildLocal'}\" OnlineExamTest.sln /p:Configuration=Debug /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
      }
    }
    stage('Restore DB') {
        steps {
            script {
                bat '"C:/Program Files (x86)/Jenkins/workspace/ch-064_dev-5TBVADSHC434SIKJRNBJG3DYKKNOTWQPUWDQEFWSDJU2CXMOOBSQ/OnlineExam.DatabaseHelper/bin/Debug/OnlineExam.DatabaseHelper.exe" restore'
            }
        }
    }
    try{
    stage('Test') {
        steps {
            bat(script: 'C:/Users/ch_admin/Desktop/NUnit.ConsoleRunner.3.8.0/tools/nunit3-console.exe  OnlineExam.NUnitTests/bin/Debug/OnlineExam.NUnitTests.dll')
        }
    }}catch(err){}
    stage('Publish report') {
        steps {
            nunit testResultsPattern: 'TestResult.xml'
        }
    }
    stage('Publish HTML') {
        steps {
            script {
                publishHTML([allowMissing: false, alwaysLinkToLastBuild: false, keepAll: false, reportDir: 'OnlineExam.NUnitTests\\Reports', reportFiles: 'MyOwnReport.html', reportName: 'HTML Report', reportTitles: ''])    
            }
        }
    }
  }
  //post {
  //      always {
  //          nunit 'TestResult.xml'
  //          publishHTML([allowMissing: false, alwaysLinkToLastBuild: false, keepAll: false, reportDir: 'OnlineExam.NUnitTests\\Reports', reportFiles: 'MyOwnReport.html', reportName: 'HTML Report', reportTitles: ''])
  //      }
  //  }
}