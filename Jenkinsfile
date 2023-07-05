pipeline {
  agent any
  stages  {
    stage('Build Image'){
      steps  {
        sh  "pwd"
        sh  'docker build -t LAB001:10 .'
      }
    }
  }
}
