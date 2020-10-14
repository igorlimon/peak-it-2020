Set-Location ..
docker build -f ./Course.Feedback/Dockerfile -t course.feedback ./Course.Feedback
docker build -f ./Course.Files/Dockerfile -t course.files ./Course.Files
docker build -f ./Course.Identity/Dockerfile -t course.identity ./Course.Identity
docker build -f ./Course.Notification/Dockerfile -t course.notification ./Course.Notification
docker build -f ./Course.Api/Dockerfile -t course.api ./Course.Api