pipeline {
    agent any

    environment {
        build_number = "${BUILD_NUMBER}"
        GIT_BRANCH = sh(script: 'echo $GIT_BRANCH | sed \'s/origin\\///\'', returnStdout: true).trim()
        branch_name = "${GIT_BRANCH}"
    }

    stages {
        stage('Build Docker Image') {
            steps {
                sh 'sudo docker build -t sicei-$branch_name:1.0.0-$build_number -f Dockerfile .'
            }
        }
        stage('List Docker Images') {
            steps {
                sh 'sudo docker image ls'
            }
        }
    }
}